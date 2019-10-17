using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface IGetRegisterById<TEntity>
    {
        TEntity GetById(Guid id);
    }
}
