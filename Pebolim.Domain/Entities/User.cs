﻿using System.ComponentModel.DataAnnotations;

namespace Pebolim.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Salt { get; set; }
        public List<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();

        public User(string username, string passwordHash, string salt)
        {
            Username = username;
            PasswordHash = passwordHash;
            Salt = salt;
        }
    }
}
