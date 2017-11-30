using FluentNHibernate.Mapping;
using Viajante.Dominio.Dominio;

namespace Viajante.Persistencia.Mapeamento
{
    public class VeiculoMap : ClassMap<Veiculo>
    {
        public VeiculoMap()
        {
            Table("Veiculo");

            Id(x => x.Id).GeneratedBy.Identity().UnsavedValue(0);
            Map(x => x.Placa).Length(7).Unique().Not.Nullable();
            Map(x => x.Chassi).Length(30).Not.Nullable();
            Map(x => x.Marca).Column("Marca").Length(30).Not.Nullable();
            Map(x => x.Modelo).Not.Nullable();
            Map(x => x.AnoModelo).Not.Nullable();
            Map(x => x.AnoFabricacao).Not.Nullable();
            Map(x => x.Inativo).Not.Nullable();
        }
    }
}
