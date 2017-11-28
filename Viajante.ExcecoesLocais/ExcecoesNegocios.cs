using System;
using System.Runtime.Serialization;
using Viajante.Comum;

namespace Viajante.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException()
            : base()
        {
        }

        public BusinessException(string Message)
            : base(Message)
        {
        }

        /// <summary>
        /// Tratamento de Erro BusinessException
        /// </summary>
        /// <param name="Message">Mensagem quer será retornada ao cliente</param>
        /// <param name="tituloMessageBox">Título da mensagem retornada ao cliente</param>
        /// <param name="messageBoxIcon">Ícone da mensagem retornada ao cliente</param>
        public BusinessException(string Message, string tituloMessageBox)
            : base(Message)
        {            
            Data.Add(Constantes.Excecao.KeyTituloMessagem, tituloMessageBox);
        }

        public BusinessException(string Message,
                                             Exception InnerException)
            : base(Message, InnerException)
        {
        }

        protected BusinessException(SerializationInfo Info,
                                                StreamingContext Context)
            : base(Info, Context)
        {
        }
    }
}
