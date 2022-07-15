using System.ComponentModel.DataAnnotations;

namespace ACC.MVC.Domain
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}
