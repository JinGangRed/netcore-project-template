using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Template.Contracts.IRepositories
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> FindAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        IEnumerable<T> Find(Func<T, bool> predicate);

        void Create(T entity);

        void CreateRange(IEnumerable<T> entities);

        void Edit(T entity);

        void Edit(IEnumerable<T> entities);

        void Delete(T entity);

        void Delete(IEnumerable<T> entitys);

        void Save();

        IEnumerable<T> Query(Expression<Func<T, bool>> expression);
    }
}
