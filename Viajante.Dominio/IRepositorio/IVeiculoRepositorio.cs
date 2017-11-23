using Viajante.Dominio.Dominio;
using Viajante.Dominio.IRepositorio.Generico;

namespace Noventa.Dominio.IRepositorio
{
    public interface IVeiculoRepositorio : IRepositorioGenerico<Veiculo>
    {
        Veiculo BuscarPelaPlaca(string placa);
    }
}
