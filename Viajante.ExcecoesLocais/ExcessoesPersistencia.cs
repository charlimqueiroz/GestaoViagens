using System;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Viajante.Comum;

namespace Viajante.Exceptions
{
    [Serializable]
    public class DAOException: Exception
    {
        public DAOException() : base()
        {
        }

        public DAOException(string Message) : base(Message)
        {
        }

        public DAOException(string Message, string tituloMessageBox, MessageBoxIcon messageBoxIcon)
            : base(Message)
        {
            Data.Add(Constantes.Excecao.KeyMessageBoxIcon, (int)messageBoxIcon);
            Data.Add(Constantes.Excecao.KeyTituloMessagem, tituloMessageBox);
        }

        public DAOException(string Message, Exception InnerException) : base(Message, InnerException)
        {
        }

        protected DAOException(SerializationInfo Info, StreamingContext Context) : base(Info, Context)
        {
        }
    }
}
