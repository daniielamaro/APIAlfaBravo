using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public interface ICreateRegister<TEntity>
    {
        TEntity Create(TEntity entity);
    }
}
