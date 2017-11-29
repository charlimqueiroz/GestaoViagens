using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Viajante.Dominio.IRepositorio.Generico
{
    public interface IRepositorioGenerico<T> where T : class
    {
        T BuscarPorId(long id);
        IList<T> BuscarTodos();
        IQueryable<T> Todos();
        T BuscarPor(Expression<Func<T, bool>> expression);
        IQueryable<T> FiltrarPor(Expression<Func<T, bool>> expression);
        void Salvar(T entity);
        void SalvarOuAtualizar(T entity);
        void Excluir(T entity);
        void Excluir(long id);
        void Atualizar(T entity);
    }
}