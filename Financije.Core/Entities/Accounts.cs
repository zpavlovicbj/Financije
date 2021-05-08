using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Financije.Core.Entities
{
    public class Accounts
    {
        [Key]
        [Required]
        public int AccountId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(30)]
        public string AccountNumber { get; set; }

        [Required]
        public int StoreId { get; set; }

        public virtual Stores Store { get; set; }

        public int DescriptionId { get; set; }

        public virtual Descriptions Description { get; set; }

        public double Payout { get; set; }

        public double Payin { get; set; }

        public int Month { get; set; }
    }
}
