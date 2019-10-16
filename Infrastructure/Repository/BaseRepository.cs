using System;
using System.Collections.Generic;
using System.Text;
using Domain.Repository;
using System.Linq;

namespace Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ApiContext ApiContext;

        public BaseRepository(ApiContext apiContext)
        {
            ApiContext = apiContext;
        }

        public void Create(TEntity entity)
        {
            ApiContext.Set<TEntity>().Add(entity);
            ApiContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            ApiContext.Set<TEntity>().Update(entity);
            ApiContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            ApiContext.Remove(entity);
            ApiContext.SaveChanges();
        }


        public TEntity SelectId(Guid id)
        {
            return ApiContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ListAll()
        {
            return ApiContext.Set<TEntity>().ToList();
        }

        // Server para descaregar a memoria do DBcontext
        public void Dispose()
        {
            ApiContext.Dispose();
        }
        
    }
}
