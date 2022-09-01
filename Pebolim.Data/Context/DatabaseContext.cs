using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pebolim.Data.Configurations;
using Pebolim.Data.Mapping;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Enumerations;

namespace Pebolim.Data.Context
{
    public class DatabaseContext : DbContext
    {
        private readonly DatabaseConfiguration _configuration;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            _configuration = new();
        }

        public DatabaseContext(
            IOptions<DatabaseConfiguration> configuration,
            DbContextOptions<DatabaseContext> options) : base(options)
        {
            _configuration = configuration.Value;
        }

        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<UserProfile>? Profiles { get; set; }
        public virtual DbSet<Team>? Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_configuration.DatabaseType.Equals(DatabaseTypes.MySQL.ToString()))
            {
                string connectionString = _configuration.ConnectionSettings ?? "server=localhost; port=3306; database=pebolim_db_d; user=pebolim_user; password=V8JjZdW!gx8E8wWp";

                optionsBuilder.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString), opt =>
                {
                    opt.CommandTimeout(120);
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<UserProfile>(new UserProfileMap().Configure);
            modelBuilder.Entity<Team>(new TeamMap().Configure);
        }
    }
}
