using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Financije.Core.Entities
{
    public class Descriptions
    {
        [Key]
        [Required]
        public int DescriptionId { get; set; }

        [Required]
        [MaxLength(30)]
        public string DescriptionName { get; set; }

        public virtual List<Accounts> Accounts { get; set; }

        public virtual List<Articles> Articles { get; set; }
    }
}
