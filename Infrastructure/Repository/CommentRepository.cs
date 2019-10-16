using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Repository;

namespace Infrastructure.Repository
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        /// <summary>
        /// Aqui entra os metodos para acesso ao DB com linq a serem chamados pelas interfaces Domain.Repository
        /// </summary>
        public CommentRepository(ApiContext apiContext) : base(apiContext)
        {

        }
    }
}
