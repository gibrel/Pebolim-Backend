using Pebolim.Domain.Entities;

namespace Pebolim.Domain.Interfaces
{
    public interface IAuthenticationService : IBaseService<User>
    {

        public Task<(bool success, string content)> Register(string username, string password);
        public Task<(bool success, string token)> Login(string username, string password);

    }
}
