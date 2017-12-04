using Viajante.Dominio.Dominio;
using Viajante.Dominio.IRepositorio.Generico;

namespace Noventa.Dominio.IRepositorio
{
    public interface IUnidadeFederacaoRepositorio : IRepositorioGenerico<UnidadeFederacao>
    {
        UnidadeFederacao BuscarPelaSigla(string sigla);
    }
}
