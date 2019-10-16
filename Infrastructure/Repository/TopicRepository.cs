using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Repository;

namespace Infrastructure.Repository
{
    public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
        /// <summary>
        /// Aqui entra os metodos para acesso ao DB com linq a serem chamados pelas interfaces Domain.Repository
        /// </summary>
        public TopicRepository(ApiContext apiContext) : base(apiContext)
        {

        }
    }
}
