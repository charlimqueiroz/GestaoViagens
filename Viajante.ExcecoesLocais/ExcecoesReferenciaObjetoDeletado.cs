using System;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Viajante.Comum;

namespace Viajante.Exceptions
{
    [Serializable]
    public class ReferencedObjectDeleteException : DAOException
    {
        public ReferencedObjectDeleteException()
            : base()
        {
        }

        public ReferencedObjectDeleteException(string Message)
            : base(Message)
        {
        }

        public ReferencedObjectDeleteException(string Message, string tituloMessageBox, MessageBoxIcon messageBoxIcon)
            : base(Message)
        {
            Data.Add(Constantes.Excecao.KeyMessageBoxIcon, (int)messageBoxIcon);
            Data.Add(Constantes.Excecao.KeyTituloMessagem, tituloMessageBox);
        }

        public ReferencedObjectDeleteException(string Message,
                                             Exception InnerException)
            : base(Message, InnerException)
        {
        }

        protected ReferencedObjectDeleteException(SerializationInfo Info,
                                                StreamingContext Context)
            : base(Info, Context)
        {
        }

    }
}
