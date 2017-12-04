using Noventa.Dominio.IRepositorio;
using System;
using System.Linq;
using Viajante.Dominio.Dominio;
using Viajante.Persistencia.Repositorio.Generico;

namespace Viajante.Persistencia.Repositorio
{
    public class EnderecoRepositorio : RepositorioGenerico<Endereco>, IEnderecoRepositorio
    {
    }
}
