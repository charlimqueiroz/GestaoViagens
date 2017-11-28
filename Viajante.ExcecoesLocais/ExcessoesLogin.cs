using System;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Viajante.Comum;

namespace Viajante.Exceptions
{
    [Serializable]
    public class LoginException : Exception
    {
        public LoginException()
            : base("Login ou senha inválidos.")
        {

        }

        public LoginException(string Message)
            : base(Message)
        {
        }

        public LoginException(string Message, string tituloMessageBox, MessageBoxIcon messageBoxIcon)
            : base(Message)
        {
            Data.Add(Constantes.Excecao.KeyMessageBoxIcon, (int)messageBoxIcon);
            Data.Add(Constantes.Excecao.KeyTituloMessagem, tituloMessageBox);
        }

        public LoginException(string Message,
                                             Exception InnerException)
            : base(Message, InnerException)
        {
        }

        protected LoginException(SerializationInfo Info,
                                                StreamingContext Context)
            : base(Info, Context)
        {
        }
    }
}
