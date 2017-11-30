using System;

namespace Viajante.Transporte.Cadastros
{
    public class TCidade
    {
        #region Atributos da Classe

        public long Id { get; set; }
        public TUnidadeFederacao UnidadeFederacao { get; set; }
        public string Nome { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string CodigoIBGE { get; set; }

        #endregion

        #region Construtor
        public TCidade()
        {
        }

        #endregion
    }
}
