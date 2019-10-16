using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    /// <summary>
    /// Aqui entra a execução dos metodos para acesso ao DB
    /// </summary>
    public interface IPublicationRepository : ICreateRegister<Publication>, IGetAll<Publication>, IGetRegisterById<Publication>
    {

    }
}
