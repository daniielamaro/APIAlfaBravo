using Domain;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    /// <summary>
    /// Aqui entra a execução dos metodos para acesso ao DB
    /// </summary>
    public interface ICommentRepository : ICreateRegister<Comment>, IGetAll<Comment>, IGetRegisterById<Comment>, IDeleteRegister<Comment>, IUpdateRegister<Comment>
    {

    }
}
