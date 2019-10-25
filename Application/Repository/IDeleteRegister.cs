using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public interface IDeleteRegister<TEntity>
    {
<<<<<<< HEAD
        TEntity Delete(Guid id);
=======
        TEntity Delete(TEntity entity);
>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b
    }
}
