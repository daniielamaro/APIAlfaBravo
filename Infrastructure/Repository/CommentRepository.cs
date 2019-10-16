using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Repository;

namespace Infrastructure.Repository
{
    public class CommentRepository : ICommentRepository
    {
        /// <summary>
        /// Aqui entra os metodos para acesso ao DB com linq a serem chamados pelas interfaces Domain.Repository
        /// </summary>
        /// 

        protected readonly ApiContext ApiContext;
        public CommentRepository(ApiContext apiContext)
        {

        }

        public Comment Delete(Guid id)
        {
            Comment comment = ApiContext.Comments.Find(id);
            ApiContext.Remove(comment);
            ApiContext.SaveChanges();

            return comment;
        }
    }
}
