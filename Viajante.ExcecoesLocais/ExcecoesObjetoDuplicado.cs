using System;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Viajante.Comum;

namespace Viajante.Exceptions
{
    [Serializable]
    public class DuplicateObjectException : DAOException
    {
        public DuplicateObjectException()
            : base()
        {
        }

        public DuplicateObjectException(string Message)
            : base(Message)
        {
        }

        public DuplicateObjectException(string Message, string tituloMessageBox, MessageBoxIcon messageBoxIcon)
            : base(Message)
        {
            Data.Add(Constantes.Excecao.KeyMessageBoxIcon, (int)messageBoxIcon);
            Data.Add(Constantes.Excecao.KeyTituloMessagem, tituloMessageBox);
        }

        public DuplicateObjectException(string Message,
                                             Exception InnerException)
            : base(Message, InnerException)
        {
        }

        protected DuplicateObjectException(SerializationInfo Info,
                                                StreamingContext Context)
            : base(Info, Context)
        {
        }
    }
}
