using Pebolim.Domain.Enumerations;

namespace Pebolim.Data.Configurations
{
    public class DatabaseConfiguration
    {
        public string? ConnectionSettings { get; set; }

        public string DatabaseType { get; set; } = DatabaseTypes.Memory.ToString();

    }
}
