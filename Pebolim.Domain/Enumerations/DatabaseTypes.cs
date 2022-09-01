using Pebolim.Domain.Helpers;

namespace Pebolim.Domain.Enumerations
{
    public class DatabaseTypes : Enumeration
    {
        public static readonly DatabaseTypes Memory = new(0, nameof(Memory));
        public static readonly DatabaseTypes MySQL = new(1, nameof(MySQL));

        public DatabaseTypes(int id, string name) : base(id, name)
        {
        }
    }
}