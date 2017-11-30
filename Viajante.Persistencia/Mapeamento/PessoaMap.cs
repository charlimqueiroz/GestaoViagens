using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using Viajante;
using Viajante.Dominio.Dominio;

namespace Viajante.Persistencia.Mapeamento
{
    public class PessoaMap : ClassMap<Pessoa>
    {
        public PessoaMap()
        {
            Table("Pessoa");

            Id(x => x.Id).GeneratedBy.Identity().UnsavedValue(0);
            References(x => x.Endereco).Column("Endereco_Id");
            References(x => x.Telefone).Column("Telefone_Id");
            Map(x => x.TipoHeranca).CustomType<TipoHerancaPessoa>().Not.Nullable();
            Map(x => x.Codigo).Not.Nullable();
            Map(x => x.CpfCnpj).Not.Nullable();
            Map(x => x.InscricaoEstadual).Not.Nullable();
            Map(x => x.InscricaoMunicipal).Not.Nullable();
            Map(x => x.TipoPessoa).CustomType<TipoPessoa>().Not.Nullable();
            Map(x => x.Site).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.NomeFantasia).Not.Nullable();
            Map(x => x.Genero).Not.Nullable();
            Map(x => x.RazaoSocial).Not.Nullable();
            Map(x => x.NumeroIdentidade).Not.Nullable();
            Map(x => x.OrgaoExpedidorIdentidade).Not.Nullable();
            References(x => x.UnidadeFederacaoIdentidace).Column("UnidadeFederacao_Id");
            Map(x => x.Nacionalidade).Not.Nullable();
            Map(x => x.TipoPessoa).CustomType<EstadoCivil>().Not.Nullable();
            Map(x => x.Profissao).Not.Nullable();
        }
    }
    public class ClienteMap : SubclassMap<Cliente>
    {
        public ClienteMap()
        {
            Table("Cliente");

            KeyColumn("Pessoa_Id");           
        }
    }


}
