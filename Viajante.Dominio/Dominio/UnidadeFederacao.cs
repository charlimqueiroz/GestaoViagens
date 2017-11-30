using System;
using Viajante;

namespace Viajante.Dominio.Dominio
{
    public class UnidadeFederacao
    {
        #region Atributos da Classe

        public virtual long Id { get; set; }
        public virtual string Sigla { get; set; }
        public virtual string Nome { get; set; }
  
        #endregion

        #region Construtor
        public UnidadeFederacao()
        {
        }

       

        #endregion

        
    }
}
