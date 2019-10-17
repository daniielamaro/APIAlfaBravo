using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface IDeleteRegister<TEntity>
    {
        TEntity Delete(Guid id);
    }
}
