using System;
using Viajante;

namespace Viajante.Transporte.Cadastros
{
    public class TTelefone
    {
        #region Atributos da Classe

        public long Id { get; set; }
        public string Numero { get; set; }
        public TipoTelefone Tipo { get; set; }
  
        #endregion

        #region Construtor
        public TTelefone()
        {
        }

        #endregion
    }
}
