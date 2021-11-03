using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Api.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        protected ApiDBContext _context;
        protected DbSet<TEntity> _dbSet;

        public BaseRepository(ApiDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity GetByKey(Guid key)
        {
            return _dbSet.Find(key);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity Add(TEntity obj)
        {
            _dbSet.Add(obj);
            return obj;
        }

        public TEntity Update(TEntity obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            return obj;
        }

        public void Delete(TEntity obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}