using System;
using Viajante;

namespace Viajante.Dominio.Dominio
{
    public class Cidade
    {
        #region Atributos da Classe

        public virtual long Id { get; set; }
        public virtual UnidadeFederacao UnidadeFederacao { get; set; }
        public virtual string Nome { get; set; }
        public virtual decimal Longitude { get; set; }
        public virtual decimal Latitude { get; set; }
        public virtual string CodigoIBGE { get; set; }
        #endregion

        #region Construtor
        public Cidade()
        {
        }

       

        #endregion

        
    }
}
