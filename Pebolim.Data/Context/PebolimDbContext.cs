using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pebolim.Data.Configurations;
using Pebolim.Data.Mapping;
using Pebolim.Domain.Entities;

namespace Pebolim.Data.Context
{
    public class PebolimDbContext : DbContext
    {
        private readonly PebolimConfiguration _configuration;

        public PebolimDbContext(DbContextOptions<PebolimDbContext> options) : base(options)
        {
            _configuration = new();
        }

        public PebolimDbContext(
            IOptions<PebolimConfiguration> configuration,
            DbContextOptions<PebolimDbContext> options) : base(options)
        {
            _configuration = configuration.Value;
        }

        public virtual DbSet<User>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_configuration.Equals("true"))
            {
                string connectionString = _configuration.WebApiDatabase ?? "server=localhost; port=3306; database=pebolim_db_d; user=pebolim_user; password=V8JjZdW!gx8E8wWp";

                optionsBuilder.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString), opt =>
                {
                    opt.CommandTimeout(120);
                });
            }
            //else
            //{
            //    optionsBuilder.UseSqlite("DataSource=:memory:");
            //    SQLitePCL.Batteries.Init();
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
        }
    }
}
