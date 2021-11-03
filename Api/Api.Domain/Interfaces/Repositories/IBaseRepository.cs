using System;
using System.Collections.Generic;

namespace Api.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Base repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get generic by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity GetByKey(Guid key);

        /// <summary>
        /// Get all generic
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Add generic
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TEntity Add(TEntity obj);

        /// <summary>
        /// Edit generic
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TEntity Update(TEntity obj);

        /// <summary>
        /// Delete generic
        /// </summary>
        /// <param name="obj"></param>
        void Delete(TEntity obj);

        /// <summary>
        /// Dispose
        /// </summary>
        void Dispose();
    }
}