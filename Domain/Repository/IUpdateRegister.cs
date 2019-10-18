using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface IUpdateRegister<TEntity>
    {
        TEntity Update(Guid id, TEntity entity);
    }
}
