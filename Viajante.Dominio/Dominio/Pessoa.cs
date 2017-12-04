using System;
using Viajante;

namespace Viajante.Dominio.Dominio
{
    public class Pessoa
    {
        #region Atributos da Classe

        public virtual long Id { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Telefone Telefone { get; set; }
        public virtual TipoHerancaPessoa TipoHeranca { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string CpfCnpj { get; set; }
        public virtual string InscricaoEstadual { get; set; }
        public virtual string InscricaoMunicipal { get; set; }
        public virtual TipoPessoa TipoPessoa { get; set; }
        public virtual string Site { get; set; }
        public virtual string Email { get; set; }
        public virtual string NomeFantasia { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual TipoGenero Genero { get; set; }
        public virtual string NumeroIdentidade { get; set; }
        public virtual string OrgaoExpedidorIdentidade { get; set; }
        public virtual UnidadeFederacao UnidadeFederacaoIdentidace { get; set; }
        public virtual string Nacionalidade { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }
        public virtual string Profissao { get; set; }

        #endregion

        #region Construtor
        public Pessoa()
        {
        }

       

        #endregion

        
    }
}
