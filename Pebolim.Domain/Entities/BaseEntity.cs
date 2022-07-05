using System.ComponentModel.DataAnnotations;

namespace Pebolim.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
