using System;
using System.Collections.Generic;
using Domain.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ApiContext ApiContext;

        public BaseRepository(ApiContext apiContext)
        {
            ApiContext = apiContext;
        }

        public TEntity Create(TEntity entity)
        {
            ApiContext.Set<TEntity>().Add(entity);
            ApiContext.SaveChanges();

            return entity;
        }

        public TEntity Update(Guid id, TEntity entity)
        {
            ApiContext.Entry(entity).State = EntityState.Modified;
            ApiContext.SaveChanges();

            return entity;
        }

        public TEntity Delete(Guid id)
        {
            TEntity entity = ApiContext.Set<TEntity>().Find(id);
            ApiContext.Remove(entity);
            ApiContext.SaveChanges();

            return entity;
        }


        public TEntity SelectId(Guid id)
        {
            return ApiContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ListAll()
        {
            return ApiContext.Set<TEntity>().ToList();
        }

        public void Dispose()
        {
            ApiContext.Dispose();
        }
        
    }
}
