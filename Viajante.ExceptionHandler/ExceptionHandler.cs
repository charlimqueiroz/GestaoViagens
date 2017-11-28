using System;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.Data.SqlClient;
using Viajante.Exceptions;

namespace Viajante
{
    public static class ExceptionHandler
    {
        public static void Handle(Exception ex, bool rethrow)
        {
            HandleException(ex);

            if (rethrow)
                throw ex;
        }

        public static void Handle(Exception ex)
        {
            if (ex.Message == "Unexpected row count: 0; expected: 1")
                return;
            HandleException(ex);
            throw ex;
        }

        public static Exception HandleAndReturn(Exception ex)
        {
            HandleException(ex);
            return ex;
        }

        private static void HandleException(Exception ex)
        {
            ExceptionLogger exLogger = new ExceptionLogger();

            Exception baseException = ex.GetBaseException();

            exLogger.LogException(ex);

            if(ex.Message.Contains("was deadlocked on lock resources") || ex.Message.Contains("deadlock victim"))
                throw new Exception("Transação foi travada em recursos de bloqueio com outro processo. Tente salvar novamente.");
            if (ex.Message.Contains("SqlDateTime"))
                throw new Exception("Todas as datas devem ter ano maior que 1753.");
            if (ex.InnerException != null && ex.InnerException.Message.Contains("contato com a 90ti"))
                throw new Exception("Parâmetro do cadastro de empresa faltando. Favor entrar em contato com a 90ti.");
            if (ex is SqlException)
                HandleSqlServerException(ex as SqlException);
            else if (baseException is SqlException)
                HandleSqlServerException(baseException as SqlException);
            else if (ex is NHibernate.HibernateException)
                HandleHibernateException(ex as NHibernate.HibernateException);
            else if (baseException is NHibernate.HibernateException)
                HandleHibernateException(baseException as NHibernate.HibernateException);
            else
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                if (ex.Message.Contains("O nome remoto não pôde ser resolvido"))
                    throw new Exception("Não foi possível fazer a integração com o Construtor de Vendas. A transação não foi realizada." + "\n" + ex.Message);
                else
                    throw new Exception(ex.Message);
            }
        }

        private static void HandleSqlServerException(SqlException ex)
        {
            SqlException exception = ex as SqlException;

            switch (exception.Number)
            {
                case (int)SQLServerError.DeleteParentRow:
                    {
                        string[] line = exception.Message.Split(new char[] { '\"' });
                        throw new ReferencedObjectDeleteException("O item não pode ser excluído porque é referência para um ou mais itens. [" + line[5].ToUpper() + "]");
                    }

                case (int)SQLServerError.AddUpdateParentRow:
                    throw new ReferencedObjectDeleteException("Operação com o item não pode ser completada porque algumas referências por ele apontadas não foram encontradas");

                case (int)SQLServerError.DuplicateKey:
                    throw new DuplicateObjectException("Duplicação de dados detectada");

                case (int)SQLServerError.DuplicateKeyInTable:
                    throw new DuplicateObjectException("Duplicação de chave detectada");

                case (int)SQLServerError.DuplicateKeyInTable2:
                    throw new DuplicateObjectException("Duplicação de chave detectada");

                case (int)SQLServerError.TableNotFound:
                    throw new DAOException("Tabela de dados não encontrada no repositório de dados");

                //Acontece quando uma query faz referência a uma coluna que não existe na tabela.
                //Pode acontecer se houver um erro no mapeamento
                case (int)SQLServerError.ColumnNotFound:
                    throw new DAOException("Coluna não encontrada no repositório de dados");

                case (int)SQLServerError.TooManyConnections:
                    throw new DAOException("Estouro do limite de conexões com o repositório de dados");

                //default: throw new System.Data.DataException("Erro de acesso ao repositório de dados." + "\n\n" + "Detalhamento:" + "\n\n" + ex.Message);
            }
        }

        private static void HandleHibernateException(NHibernate.HibernateException ex)
        {
            if (ex.GetBaseException() is System.Net.Sockets.SocketException)
                throw ex.GetBaseException() as System.Net.Sockets.SocketException;

            if (ex is NHibernate.MappingException)
                throw new DAOException("O mapeamento dos dados contém erros");
            else if (ex.InnerException != null && ex.InnerException.Message.Contains("SqlDateTime"))
                throw new DAOException("Todas as datas devem ter ano maior que 1753");
            else if (ex is NHibernate.ADOException)
                throw new DAOException("Erro na consulta ao repositório de dados");
            else if (ex is NHibernate.ObjectNotFoundException)
                throw new DAOException("Objeto procurado não encontrado");           
            else
                throw new DAOException("Erro genérico do gerenciador de acesso ao repositório de dados");
        }
    }

    public enum SQLServerError : int
    {
        [Description("Can't write; duplicate key in table '%s'")]
        DuplicateKeyInTable = 1022,

        [Description("Can't write; duplicate key in table '%s'")]
        DuplicateKeyInTable2 = 2601,

        [Description("Too many connections")]
        TooManyConnections = 1040,

        [Description("Unknown column '%s' in '%s'")]
        ColumnNotFound = 207,

        [Description("Duplicate entry '%s' for key %d")]
        DuplicateKey = 2627,

        [Description("Table '%s.%s' doesn't exist ")]
        TableNotFound = 1146,

        [Description("Cannot delete or update a parent row: a foreign key constraint fails (%s)")]
        DeleteParentRow = 547,

        [Description("Cannot add or update a child row: a foreign key constraint fails (%s)")]
        AddUpdateParentRow = 1452
    }

    public class ExceptionLogger
    {
        const string sSource = "Regente.NET";
        const string sLog = "Application";
        const string sEvent = "Log Event";

        private Exception ex;
        private System.Threading.Thread thread;

        private static object lockFlag = new object();

        //private System.Threading.ThreadStart pThread;


        public void LogException(Exception ex)
        {
            this.ex = ex;

            //pThread = new System.Threading.ThreadStart(LogToFile);

            thread = new System.Threading.Thread(new System.Threading.ThreadStart(LogToFile));

            thread.Start();
            //LogToFile();
        }

        private void LogByThread()
        {
            //try
            //{
            //    LogToWebService();
            //}
            //Por enquanto a exceção é engolida para não gerar uma exceção diferente no cliente. No futuro pode-se achar
            //uma utilidade para o bloco catch.
            //catch
            //{ }

            try
            {
                LogToFile();
            }
            //Por enquanto a exceção é engolida para não gerar uma exceção diferente no cliente. No futuro pode-se achar
            //uma utilidade para o bloco catch.
            catch
            { }
        }

        private void LogToFile()
        {
            var strippedException = StripException(ex);

            lock (lockFlag)
            {
                try
                {
                    System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "TraceError.log", strippedException);
                }
                catch (Exception exx)
                {
                    if (!EventLog.SourceExists(sSource))
                        EventLog.CreateEventSource(sSource, sLog);

                    EventLog.WriteEntry(sSource, exx.StackTrace.ToString(), EventLogEntryType.Error);
                }
            }
        }

        private void LogToWebService()
        {
            //ExceptionLogReceiver logger = new ExceptionLogReceiver();
            //logger.LogException(StripException(ex), "cliente");
        }

        private string StripException(Exception ex)
        {
            string innerExceptionSeparator = Environment.NewLine + "---------------------------------------------------------------------" + Environment.NewLine;
            string exceptionSeparator = Environment.NewLine + "---------------------------FIM DA EXCEÇÃO----------------------------" + Environment.NewLine;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Data: " + DateTime.Now.Date + " ");
            sb.AppendLine("Hora: " + DateTime.Now.ToLongTimeString() + Environment.NewLine + Environment.NewLine);

            //sb.AppendLine("IdEmpresa: " + SessionManager.GetSession().IdEmpresa + Environment.NewLine);
            //sb.AppendLine("IdUsuario: " + SessionManager.GetSession().IdUsuario + Environment.NewLine + Environment.NewLine);

            sb.AppendLine("DADOS DO SERVIDOR" + Environment.NewLine);
            sb.AppendLine("Diretório Base: " + AppDomain.CurrentDomain.BaseDirectory);

            sb.AppendLine("HostName: " + System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().HostName + Environment.NewLine);
            sb.AppendLine("MachineName: " + System.Environment.MachineName + Environment.NewLine);
            sb.AppendLine("OS: " + System.Environment.OSVersion.Platform.ToString() + Environment.NewLine);
            sb.AppendLine("ServicePack: " + System.Environment.OSVersion.ServicePack + Environment.NewLine);
            sb.AppendLine("Version: " + System.Environment.OSVersion.VersionString + Environment.NewLine);
            sb.AppendLine("MemSet: " + System.Environment.WorkingSet + Environment.NewLine);
            sb.AppendLine("Processadores: " + System.Environment.ProcessorCount + Environment.NewLine);

            sb.AppendLine("Tipo: " + ex.GetType().ToString() + Environment.NewLine + Environment.NewLine);

            sb.AppendLine("Mensagem: " + ex.Message);
            sb.AppendLine(innerExceptionSeparator);

            while (ex.InnerException != null)
            {
                ex = ex.InnerException;

                sb.AppendLine("Tipo: " + ex.GetType().ToString() + Environment.NewLine + Environment.NewLine);
                sb.AppendLine("Mensagem: " + ex.Message + Environment.NewLine + Environment.NewLine);

                sb.AppendLine(innerExceptionSeparator);
            }

            sb.AppendLine("StackTrace: " + ex.StackTrace);

            sb.AppendLine(exceptionSeparator);

            return sb.ToString();
        }
    }
}
