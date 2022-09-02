using Pebolim.Domain.Helpers;

namespace Pebolim.Domain.Enumerations
{
    public class Formation : Enumeration
    {
        public static readonly Formation Formation_4_3_3 = new Formation(0, nameof(Formation_4_3_3));
        public static readonly Formation Formation_4_4_2 = new Formation(1, nameof(Formation_4_4_2));
        public static readonly Formation Formation_3_5_2 = new Formation(2, nameof(Formation_3_5_2));
        public static readonly Formation Formation_3_4_3 = new Formation(3, nameof(Formation_3_4_3));
        public static readonly Formation Formation_4_5_1 = new Formation(4, nameof(Formation_4_5_1));
        public static readonly Formation Formation_5_3_2 = new Formation(5, nameof(Formation_5_3_2));

        public Formation(int id, string name) : base(id, name)
        {
        }
    }
}