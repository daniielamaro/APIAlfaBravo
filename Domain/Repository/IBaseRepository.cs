using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Create(TEntity entity);
        TEntity SelectId(int id);
        IEnumerable<TEntity> ListAll();
        void Update(TEntity entity);
        void Delete(TEntity entity);    
    }
}
