using System;
using Viajante;

namespace Viajante.Dominio.Dominio
{
    public class Pessoa
    {
        #region Atributos da Classe

        public virtual long Id { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
        public TipoHerancaPessoa TipoHeranca { get; set; }
        public string Codigo { get; set; }
        public string CpfCnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string Site { get; set; }
        public string Email { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public TipoGenero Genero { get; set; }
        public string NumeroIdentidade { get; set; }
        public string OrgaoExpedidorIdentidade { get; set; }
        public virtual UnidadeFederacao UnidadeFederacaoIdentidace { get; set; }
        public string Nacionalidade { get; set; }
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
