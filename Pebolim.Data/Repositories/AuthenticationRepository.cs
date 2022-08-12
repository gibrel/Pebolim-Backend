using Pebolim.Data.Context;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Pebolim.Data.Repositories
{
    public class AuthenticationRepository : BaseRepository<User>, IAuthenticationRepository
    {
        public AuthenticationRepository(PebolimDbContext pebolimDbContext) : base(pebolimDbContext)
        {

        }

        public async Task<bool> ExistsUsername(string username)
        {
            if (_pebolimDbContext.Users != null)
                return await _pebolimDbContext.Users.AnyAsync(u => u.Username == username);
            return true;
        }

        public async Task<User?> SelectByUsername(string username)
        {
            if (_pebolimDbContext.Users != null)
                return await _pebolimDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            return null;
        }
    }
}
