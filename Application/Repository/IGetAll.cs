using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public interface IGetAll<TEntity>
    {
        IEnumerable<TEntity> GetAll();
    }
}
