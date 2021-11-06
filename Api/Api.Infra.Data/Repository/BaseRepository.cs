using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Api.Infra.Data.Repository
{
    /// <summary>
    /// Base repository
    /// </summary>
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Database context
        /// </summary>
        protected ApiDBContext _context;

        /// <summary>
        /// Database set
        /// </summary>
        protected DbSet<TEntity> _dbSet;

        /// <summary>
        /// Base repository constructor
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(ApiDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        /// <summary>
        /// Method get generic entity by key
        /// </summary>
        public TEntity GetByKey(Guid key)
        {
            return _dbSet.Find(key);
        }

        /// <summary>
        /// Method get all generic entity
        /// </summary>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        /// <summary>
        /// Method add generic entity
        /// </summary>
        public TEntity Add(TEntity obj)
        {
            _dbSet.Add(obj);
            return obj;
        }

        /// <summary>
        /// Method update generic entity
        /// </summary>
        public TEntity Update(TEntity obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            return obj;
        }

        /// <summary>
        /// Method delete generic entity
        /// </summary>
        public void Delete(TEntity obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        /// <summary>
        /// Method dispose
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}