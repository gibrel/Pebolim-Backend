using Pebolim.Domain.Entities;
using Pebolim.UnitTest.Helpers;
using System.Security.Cryptography;

namespace Pebolim.UnitTest.Fixtures
{
    public static class UserFixture
    {
        public static readonly Random _random = new();

        public static User GenerateUser(int id = 0)
        {
            var salt = GenerateRandomSalt();
            var userId = id < 0 ? RandomNumberGenerator.GetInt32(2000000000) : id;

            return new User(
                username: GenerateRandomUsername(),
                passwordHash: GenerateRandomPasswordHash(salt),
                salt: salt)
            {
                Id = userId
            };
        }

        public static User MakeChanges(User user)
        {
            int seed = _random.Next(7);

            switch (seed)
            {
                case 0:
                    ChangeUsername(user);
                    break;
                case 1:
                    ChangePasswordHash(user);
                    break;
                case 2:
                    ChangeSalt(user);
                    break;
                case 3:
                    ChangeUsername(user);
                    ChangePasswordHash(user);
                    break;
                case 4:
                    ChangeSalt(user);
                    ChangeUsername(user);
                    break;
                case 5:
                    ChangeSalt(user);
                    ChangePasswordHash(user);
                    break;
                default:
                    ChangeUsername(user);
                    ChangeSalt(user);
                    ChangePasswordHash(user);
                    break;
            }

            return user;
        }

        private static void ChangeUsername(User user)
        {
            var newUsername = GenerateRandomUsername();
            if (newUsername != user.Username)
                user.Username = newUsername;
            else ChangeUsername(user);
        }

        private static void ChangePasswordHash(User user)
        {
            var newPasswordHash = GenerateRandomPasswordHash(user.Salt);
            if (newPasswordHash != user.PasswordHash)
                user.PasswordHash = newPasswordHash;
            else ChangePasswordHash(user);
        }

        private static void ChangeSalt(User user)
        {
            var newSalt = GenerateRandomSalt();
            if (newSalt != user.Salt)
                user.Salt = newSalt;
            else ChangeSalt(user);
        }

        private static string GenerateRandomUsername()
        {
            var passwordHash = RandomStringGenerator.GenerateName(6, 30);
            return passwordHash;
        }

        private static string GenerateRandomPasswordHash(string saltString)
        {
            var password = RandomStringGenerator.Generate(64);

            var salt = Convert.FromBase64String(saltString);
            using var hashGenerator = new Rfc2898DeriveBytes(password, salt);
            hashGenerator.IterationCount = RandomNumberGenerator.GetInt32(10000) + 102;
            var bytes = hashGenerator.GetBytes(64);

            return Convert.ToBase64String(bytes);
        }

        private static string GenerateRandomSalt()
        {
            var rng = RandomNumberGenerator.Create();
            var salt = new byte[64];
            rng.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }
    }
}
