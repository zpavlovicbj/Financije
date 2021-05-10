using System.ComponentModel.DataAnnotations;

namespace Financije.Core.Entities
{
    public class AccountItem
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        public int ArticleId { get; set; }

        public virtual Articles Article { get; set; }

        public double Price { get; set; }
    }
}
