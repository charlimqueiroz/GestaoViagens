using System;
using Viajante;

namespace Viajante.Transporte.Cadastros
{
    public class TEndereco
    {
        #region Atributos da Classe

        public virtual long Id { get; set; }
        public virtual TUnidadeFederacao UnidadeFederacao { get; set; }
        public virtual TCidade Cidade { get; set; }
        public TipoLogradouro TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public TipoBairro TipoBairro { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public virtual decimal Longitude { get; set; }
        public virtual decimal Latitude { get; set; }
        #endregion

        #region Construtor
        public TEndereco()
        {
        }

       

        #endregion

        
    }
}
