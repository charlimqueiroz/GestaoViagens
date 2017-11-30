using System;
using Viajante;

namespace Viajante.Dominio.Dominio
{
    public class Telefone
    {
        #region Atributos da Classe

        public virtual long Id { get; set; }
        public virtual string Numero { get; set; }
        public virtual TipoTelefone Tipo { get; set; }
  
        #endregion

        #region Construtor
        public Telefone()
        {
        }

       

        #endregion

        
    }
}
