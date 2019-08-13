using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Template.Contracts.IRepositories
{
    /// <summary>
    /// The root repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T:class
    {
        /// <summary>
        /// Get all the entity
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();
        /// <summary>
        /// Get all the entity according to the expression
        /// </summary>
        /// <param name="expression">Filter expression</param>
        /// <returns></returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        /// <summary>
        /// Get all the entity according to the predicate
        /// </summary>
        /// <param name="predicate">Filter predicate</param>
        /// <returns></returns>
        IEnumerable<T> Find(Func<T, bool> predicate);
        /// <summary>
        /// Create an entity
        /// </summary>
        /// <param name="entity">The entity will be ceated</param>
        void Create(T entity);
        /// <summary>
        /// Create some entities
        /// </summary>
        /// <param name="entities"></param>
        void CreateRange(IEnumerable<T> entities);
        /// <summary>
        /// Modify an entity
        /// </summary>
        /// <param name="entity"></param>
        void Edit(T entity);
        /// <summary>
        /// Modify some entity
        /// </summary>
        /// <param name="entity"></param>
        void Edit(IEnumerable<T> entities);
        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        void Delete(IEnumerable<T> entitys);

        void Save();

        IEnumerable<T> Query(Expression<Func<T, bool>> expression);
    }
}
