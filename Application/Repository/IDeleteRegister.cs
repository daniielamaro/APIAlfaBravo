using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public interface IDeleteRegister<TEntity>
    {

        TEntity Delete(TEntity entity);
    }
}
