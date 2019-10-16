using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    /// <summary>
    /// Aqui entra a execução dos metodos para acesso ao DB
    /// </summary>
    public interface ITopicRepository : ICreateRegister<Topic>, IGetAll<Topic>
    {

    }
}
