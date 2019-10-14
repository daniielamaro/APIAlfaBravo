using Domain;
using Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository 
{
    
    public class PublicationRepository : BaseRepository<Publication>, IPublicationRepository
    {
        /// <summary>
        /// Aqui entra os metodos para acesso ao DB com linq a serem chamados pelas interfaces Domain.Repository
        /// </summary>
        public PublicationRepository(ApiContext apiContext) : base(apiContext)
        {

        }
    }
}
