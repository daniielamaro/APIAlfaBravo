using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public interface IRegisterDB
    {
        void CreateNew(Publication entity);
    }
}
