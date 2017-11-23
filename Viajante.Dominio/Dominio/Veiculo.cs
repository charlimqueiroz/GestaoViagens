using System;

namespace Viajante.Dominio.Dominio
{
    public class Veiculo
    {
        #region Atributos da Classe

        public virtual long Id { get; set; }
        public virtual string Placa { get; set; }
        public virtual string Chassi { get; set; }
        public virtual string Marca { get; set; }
        public virtual string Modelo { get; set; }
        public virtual int AnoModelo { get; set; }
        public virtual int AnoFabricacao { get; set; }
        public virtual bool Inativo { get; set; }
  
        #endregion

        #region Construtor
        public Veiculo()
        {
        }

       

        #endregion

        
    }
}
