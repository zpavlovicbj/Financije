using System.ComponentModel.DataAnnotations;

namespace Financije.Core.Entities
{
    public class AccountItems
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        public int ArticleId { get; set; }

        public virtual Articles Article { get; set; }

        public double Payout { get; set; }

        public double Payin { get; set; }
    }
}
