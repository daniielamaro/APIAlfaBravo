using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    /// <summary>
    /// Aqui entra a execução dos metodos para acesso ao DB
    /// </summary>
    public interface IPublicationRepository : ICreateRegister<Publication>, IGetAll<Publication>, IDeleteRegister<Publication>, IGetRegisterById<Publication>, IUpdateRegister<Publication>
    {
<<<<<<< HEAD
        List<Publication> GetByName(string name);
=======

>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b
    }
}
