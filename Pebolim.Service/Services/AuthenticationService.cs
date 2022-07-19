using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Helpers;
using Pebolim.Domain.Interfaces;
using Pebolim.Service.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pebolim.Service.Services
{
    public class AuthenticationService : BaseService<User>, Domain.Interfaces.IAuthenticationService
    {
        private readonly WebApiConfigurations _configuration;
        protected readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(
            IAuthenticationRepository authenticationRepository,
            IMapper mapper
        ) : base(authenticationRepository, mapper)
        {
            _configuration = new();
            _authenticationRepository = authenticationRepository;
        }

        public async Task<(bool success, string content)> Register(string username, string password)
        {
            if (await _authenticationRepository.ExistsUsername(username)) return (false, "Username unavailable.");

            User user = new(username, password, "");
            user.ProvideSaltAndHash();

            if (await _authenticationRepository.Insert(user)) return (true, "Success");

            return (false, "Failed to register user.");
        }

        public async Task<(bool success, string token)> Login(string username, string password)
        {
            const string FailureMessage = "Invalid login attempt";

            User user = await _authenticationRepository.SelectByUsername(username);
            if (user == null ||
                user.PasswordHash != AuthenticationHelpers.ComputeHash(password, user.Salt))
                return (false, FailureMessage);

            return (true, GenerateJwtToken(AssembleClaimsIdentity(user)));
        }

        private static ClaimsIdentity AssembleClaimsIdentity(User user)
        {
            var subject = new ClaimsIdentity(new[]
            {
                new Claim("id", user.Id.ToString()),
            });

            return subject;
        }

        private string GenerateJwtToken(ClaimsIdentity subject)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.BearerKey ?? "@fXhMXL6Zekd8&yA");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
