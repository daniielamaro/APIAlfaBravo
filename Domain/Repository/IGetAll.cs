using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface IGetAll<TEntity>
    {
        IEnumerable<TEntity> ListAll();
    }
}
