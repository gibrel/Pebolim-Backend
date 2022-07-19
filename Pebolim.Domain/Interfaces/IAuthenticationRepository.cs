using Pebolim.Domain.Entities;

namespace Pebolim.Domain.Interfaces
{
    public interface IAuthenticationRepository : IBaseRepository<User>
    {

        Task<bool> ExistsUsername(string username);
        Task<User> SelectByUsername(string username);
    }
}
