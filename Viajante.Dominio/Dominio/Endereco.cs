using System;
using Viajante;

namespace Viajante.Dominio.Dominio
{
    public class Endereco
    {
        #region Atributos da Classe

        public virtual long Id { get; set; }
        public virtual UnidadeFederacao UnidadeFederacao { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual TipoLogradouro TipoLogradouro { get; set; }
        public virtual string Logradouro { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Complemento { get; set; }
        public virtual TipoBairro TipoBairro { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cep { get; set; }
        public virtual decimal Longitude { get; set; }
        public virtual decimal Latitude { get; set; }
        #endregion

        #region Construtor
        public Endereco()
        {
        }

       

        #endregion

        
    }
}
