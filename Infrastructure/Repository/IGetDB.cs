using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public interface IGetDB<TEntity>
    {
        List<TEntity> GetAllRegister();
        TEntity GetRegisterById(Guid id);
    }
}
