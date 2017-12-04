using Noventa.Dominio.IRepositorio;
using System;
using System.Linq;
using Viajante.Dominio.Dominio;
using Viajante.Persistencia.Repositorio.Generico;

namespace Viajante.Persistencia.Repositorio
{
    public class UnidadeFederacaoRepositorio : RepositorioGenerico<UnidadeFederacao>, IUnidadeFederacaoRepositorio
    {
        public UnidadeFederacao BuscarPelaSigla(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
                throw new ArgumentOutOfRangeException("Sigla do Estado não informada.");

            return GetSessao().Query<UnidadeFederacao>().Where(i => i.Sigla == sigla).FirstOrDefault();
        }
    }
}
