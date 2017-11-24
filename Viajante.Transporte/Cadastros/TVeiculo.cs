using System;

namespace Viajante.Transporte.Cadastros
{
    public class TVeiculo
    {
        #region Atributos da Classe

        public long Id { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }
        public bool Inativo { get; set; }
  
        #endregion

        #region Construtor
        public TVeiculo()
        {
        }

        #endregion

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null) return false;
            TVeiculo castObj = (TVeiculo)obj;
            return (castObj != null) &&
                (this.Id == castObj.Id);
        }

        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * Id.GetHashCode();
            return hash;
        }
        #endregion

    }
}
