using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public interface ICreateDB<TEntity>
    {
        void CreateNewRegister(TEntity entity);
    }
}
