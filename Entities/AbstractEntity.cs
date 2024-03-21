using System.ComponentModel.DataAnnotations;

namespace Webia.Entities
{
    public abstract class AbstractEntity
    {
        [Key]
        public Guid Id { get; set; }

        public AbstractEntity()
        {
                
        }
    }
}
