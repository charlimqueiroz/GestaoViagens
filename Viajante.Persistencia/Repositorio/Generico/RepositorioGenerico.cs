using NHibernate;
using NHibernate.Linq;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using Viajante.Dominio.IRepositorio.Generico;

namespace Viajante.Persistencia.Repositorio.Generico
{    
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly ISession _session;
        private T classeDePersistencia;

        public RepositorioGenerico()
        {
            NHibernateHelper NHHelper = new NHibernateHelper();
            _session = NHHelper.SessionFactory.OpenSession();
        }

        public ISession GetSessao()
        {
            return _session;
        }

        #region Implementation of IRepository<T>

        public T BuscarPorId(long id)
        {
            return _session.Get<T>(id);
        }

        public IList<T> BuscarTodos()
        {
            return _session.Query<T>().ToList(); ;
        }       

        public IQueryable<T> Todos()
        {
            return _session.Query<T>();
        }

        public T BuscarPor(Expression<Func<T, bool>> expression)
        {
            return FiltrarPor(expression).SingleOrDefault();
        }

        public IQueryable<T> FiltrarPor(Expression<Func<T, bool>> expression)
        {
            return Todos().Where(expression).AsQueryable();
        }

        #endregion

        #region SaveOrUpdate
        public void SalvarEAtualizar(T entity)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);
                tran.Commit();
            }
        }

        #endregion

        #region Save
        public void Salvar(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Não é possível salvar a entidade.");

            using (var tran = _session.BeginTransaction())
            {
                _session.Save(entity);
                tran.Commit();
            }
        }

        //public void SaveAndFlush(T entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException("Não é possível salvar uma entidade nula");

        //    Save(entity);
        //    HibernateLoader.GetSession().Flush();
        //}

        #endregion

        #region Delete
        public virtual void Excluir(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Não é possível excluir a entidade.");

            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(entity);
                tran.Commit();
            }

            

            //_session.Delete(entity);
        }

        //public void DeleteAndFlush(T entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException("Não é possível excluir uma entidade nula");

        //    Delete(entity);
        //    HibernateLoader.GetSession().Flush();
        //}

        public virtual void Excluir(long id)
        {
            if (id.Equals(0))
                throw new ArgumentOutOfRangeException("Não é possível excluir um registro com Id igual a 0.");

            classeDePersistencia = BuscarPorId(id);
            Excluir(classeDePersistencia);
        }

        //public void DeleteAndFlush(ID id)
        //{
        //    Delete(id);
        //    HibernateLoader.GetSession().Flush();
        //}

        #endregion

        #region Update
        public virtual void Atualizar(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Não é possível atualizar uma entidade nula");

            using (var tran = _session.BeginTransaction())
            {
                _session.Update(entity);
                tran.Commit();
            }
        }

        //public void UpdateAndFlush(T entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException("Não é possível atualizar uma entidade nula");

        //    Update(entity);
        //    HibernateLoader.GetSession().Flush();
        //}
        #endregion

    }
}
