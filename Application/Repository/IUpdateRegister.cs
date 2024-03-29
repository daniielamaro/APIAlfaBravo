﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public interface IUpdateRegister<TEntity>
    {
        TEntity Update(TEntity entity);
    }
}
