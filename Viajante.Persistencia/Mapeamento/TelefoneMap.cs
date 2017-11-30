using FluentNHibernate.Mapping;
using Viajante;
using Viajante.Dominio.Dominio;

namespace Viajante.Persistencia.Mapeamento
{
    public class TelefoneMap : ClassMap<Telefone>
    {
        public TelefoneMap()
        {
            Table("Telefone");

            Id(x => x.Id).GeneratedBy.Identity().UnsavedValue(0);
            Map(x => x.Numero).Not.Nullable();
            Map(x => x.Tipo).CustomType<TipoTelefone>().Not.Nullable();
        }
    }
}
