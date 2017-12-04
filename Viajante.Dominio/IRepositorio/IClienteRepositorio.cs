using Viajante.Dominio.Dominio;
using Viajante.Dominio.IRepositorio.Generico;

namespace Noventa.Dominio.IRepositorio
{
    public interface IClienteRepositorio : IRepositorioGenerico<Cliente>
    {
        Cliente BuscarPeloCodigo(string codigo);
    }
}
