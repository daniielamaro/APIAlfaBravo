using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public interface IGetRegisterById<TEntity>
    {
        TEntity GetById(Guid id);
    }
}
