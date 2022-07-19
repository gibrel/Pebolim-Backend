using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Pebolim.Data.Context;

namespace Pebolim.UnitTest.Fixtures
{
    public class ConnectionFactory : IDisposable
    {
        private bool disposedValue = false;

        public static PebolimDbContext CreateContextForSQLite()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var option = new DbContextOptionsBuilder<PebolimDbContext>().UseSqlite(connection).Options;

            var context = new PebolimDbContext(option);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
