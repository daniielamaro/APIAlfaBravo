using Domain;
using Domain.Repository;
using System.Linq;

namespace Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        /// <summary>
        /// Aqui entra os metodos para acesso ao DB com linq a serem chamados pelas interfaces Domain.Repository
        /// </summary>
        public UserRepository(ApiContext apiContext) : base(apiContext)
        {

        }
    }
}
