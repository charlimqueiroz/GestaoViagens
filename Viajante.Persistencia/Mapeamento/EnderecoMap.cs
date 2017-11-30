using FluentNHibernate.Mapping;
using Viajante;
using Viajante.Dominio.Dominio;

namespace Viajante.Persistencia.Mapeamento
{
    public class EnderecoMap : ClassMap<Endereco>
    {
        public EnderecoMap()
        {
            Table("Endereco");

            Id(x => x.Id).GeneratedBy.Identity().UnsavedValue(0);
            References(x => x.UnidadeFederacao).Column("UnidadeFederacao_Id");
            References(x => x.Cidade).Column("Cidade_Id");
            Map(x => x.TipoLogradouro).CustomType<TipoLogradouro>().Not.Nullable();
            Map(x => x.Logradouro).Not.Nullable();
            Map(x => x.Numero).Not.Nullable();
            Map(x => x.Complemento).Not.Nullable();
            Map(x => x.TipoBairro).CustomType<TipoBairro>().Not.Nullable();
            Map(x => x.Bairro).Not.Nullable();
            Map(x => x.Cep).Not.Nullable();
            Map(x => x.Longitude).Not.Nullable();
            Map(x => x.Latitude).Not.Nullable();
        }
    }
}
