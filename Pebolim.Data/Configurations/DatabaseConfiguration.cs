using Pebolim.Domain.Enumerations;

namespace Pebolim.Data.Configurations
{
    public class DatabaseConfiguration
    {
        public string ConnectionSettings { get; set; } = "server=host.docker.internal; database=pebolim_db_d; user=pebolim_user; password=V8JjZdW!gx8E8wWp";

        public string DatabaseType { get; set; } = DatabaseTypes.Memory.ToString();

    }
}
