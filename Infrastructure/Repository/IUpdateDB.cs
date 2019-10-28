using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public interface IUpdateDB<TEntity>
    {
        void UpdateRegister(TEntity entity);
    }
}
