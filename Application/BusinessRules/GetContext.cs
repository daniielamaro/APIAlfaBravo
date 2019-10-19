using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessRules
{
    public sealed class GetContext
    {
        public readonly ApiContext Context;

        public GetContext()
        {
            Context = new ApiContext();
        }
    }
}
