using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface ICreateRegister<TEntity>
    {
        TEntity Create(TEntity entity);
    }
}
