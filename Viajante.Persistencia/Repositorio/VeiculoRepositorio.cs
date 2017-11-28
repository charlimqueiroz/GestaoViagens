using Noventa.Dominio.IRepositorio;
using System;
using System.Linq;
using Viajante.Dominio.Dominio;
using Viajante.Persistencia.Repositorio.Generico;

namespace Viajante.Persistencia.Repositorio
{
    public class VeiculoRepositorio : RepositorioGenerico<Veiculo>, IVeiculoRepositorio
    {
        public Veiculo BuscarPelaPlaca(string placa)
        {
            if (string.IsNullOrEmpty(placa))
                throw new ArgumentOutOfRangeException("Placa do veículo não informada.");

            return GetSessao().Query<Veiculo>().Where(i => i.Placa == placa).FirstOrDefault();
        }
    }
}
