using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pebolim.Data.Configurations;
using Pebolim.Data.Mapping;
using Pebolim.Domain.Entities;

namespace Pebolim.Data.Context
{
    public class MySqlContext : DbContext
    {
        private readonly MySqlConfiguration _configuration;

        public MySqlContext(
            IOptions<MySqlConfiguration> configuration,
            DbContextOptions<MySqlContext> options) : base(options)
        {
            _configuration = configuration.Value;
        }

        public DbSet<User>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.WebApiDatabase ?? "server=localhost; database=database; user=user; password=password";

            optionsBuilder.UseMySql(connectionString, 
                ServerVersion.AutoDetect(connectionString), opt =>
            {
                opt.CommandTimeout(120);
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
        }
    }
}
