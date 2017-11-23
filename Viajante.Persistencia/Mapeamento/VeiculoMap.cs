using FluentNHibernate.Mapping;
using Viajante.Dominio.Dominio;

namespace Viajante.Persistencia.Mapeamento
{
    public class VeiculoMap : ClassMap<Veiculo>
    {
        public VeiculoMap()
        {
            Id(x => x.Id);
            Map(x => x.Placa).Length(7).Unique().Not.Nullable();
            Map(x => x.Chassi).Length(30).Not.Nullable();
            Map(x => x.Marca).Column("Marca").Not.Nullable();
            Map(x => x.Modelo).Column("Marca").Not.Nullable();
            Map(x => x.AnoModelo).Column("Marca").Not.Nullable();
            Map(x => x.AnoFabricacao).Column("Marca").Not.Nullable();
            Map(x => x.Inativo).Not.Nullable();

            Table("Veiculo");
        }
    }
}
