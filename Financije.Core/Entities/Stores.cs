using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Financije.Core.Entities
{
    public class Stores
    {
        [Key]
        [Required]
        public int StoresId { get; set; }

        [Required]
        [MaxLength(30)]
        public string StoreName { get; set; }

        public virtual List<Accounts> Accounts { get; set; }
    }
}
