using FluentNHibernate.Mapping;
using Viajante;
using Viajante.Dominio.Dominio;

namespace Viajante.Persistencia.Mapeamento
{
    public class UnidadeFederacaoMap : ClassMap<UnidadeFederacao>
    {
        public UnidadeFederacaoMap()
        {
            Table("Unidade_Federacao");

            Id(x => x.Id).GeneratedBy.Identity().UnsavedValue(0);
            Map(x => x.Nome).Not.Nullable();
            Map(x => x.Sigla).CustomType<TipoTelefone>();


        }
    }
}
