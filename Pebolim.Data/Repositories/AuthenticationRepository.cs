using Pebolim.Data.Context;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;

namespace Pebolim.Data.Repositories
{
    public class AuthenticationRepository : BaseRepository<User>, IAuthenticationRepository
    {
        public AuthenticationRepository(PebolimDbContext pebolimDbContext) : base(pebolimDbContext)
        {

        }

        public async Task<bool> ExistsUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<User> SelectByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
