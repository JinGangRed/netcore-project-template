using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Template.Contracts.IRepositories;
using Template.DbDomain;

namespace Template.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly RepositoryContext RepositoryContext;
        public Repository(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
            Save();
        }

        public void CreateRange(IEnumerable<T> entities)
        {
            RepositoryContext.Set<T>().AddRange(entities);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
            Save();
        }

        public void Delete(IEnumerable<T> entitys)
        {
            RepositoryContext.RemoveRange(entitys);
            Save();
        }

        public void Edit(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
            Save();
        }

        public void Edit(IEnumerable<T> entities)
        {
            RepositoryContext.UpdateRange(entities);
            Save();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().AsNoTracking().Where(expression);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return RepositoryContext.Set<T>().AsNoTracking().Where(predicate);
        }

        public IEnumerable<T> FindAll()
        {
            return RepositoryContext.Set<T>();
        }

        public void Save()
        {
            RepositoryContext.SaveChanges();
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Query<T>().Where(expression);
        }
    }
}
