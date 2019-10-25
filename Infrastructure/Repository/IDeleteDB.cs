using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public interface IDeleteDB<TEntity>
    {
        void DeleteRegister(TEntity entity);
    }
}
