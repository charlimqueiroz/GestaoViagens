using Noventa.Dominio.IRepositorio;
using System;
using System.Linq;
using Viajante.Dominio.Dominio;
using Viajante.Persistencia.Repositorio.Generico;

namespace Viajante.Persistencia.Repositorio
{
    public class ClienteRepositorio : RepositorioGenerico<Cliente>, IClienteRepositorio
    {
        public Cliente BuscarPeloCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
                throw new ArgumentOutOfRangeException("Código do veículo não informado.");

            return GetSessao().Query<Cliente>().Where(i => i.Codigo == codigo).FirstOrDefault();
        }
    }
}
