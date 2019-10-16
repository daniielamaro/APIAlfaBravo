using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Create(TEntity entity);
        TEntity SelectId(Guid id);
        IEnumerable<TEntity> ListAll();
        TEntity Update(Guid id, TEntity entity);
        TEntity Delete(Guid id);    
    }
}
