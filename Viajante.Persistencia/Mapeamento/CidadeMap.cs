using FluentNHibernate.Mapping;
using Viajante;
using Viajante.Dominio.Dominio;

namespace Viajante.Persistencia.Mapeamento
{
    public class CidadeMap : ClassMap<Cidade>
    {
        public CidadeMap()
        {
            Table("Cidade");

            Id(x => x.Id).GeneratedBy.Identity().UnsavedValue(0);
            References(x => x.UnidadeFederacao).Column("UnidadeFederacao_Id");
            Map(x => x.Nome).Not.Nullable();
            Map(x => x.Longitude).Not.Nullable();
            Map(x => x.Latitude).Not.Nullable();
            Map(x => x.CodigoIBGE).Not.Nullable();
        }
    }
}
