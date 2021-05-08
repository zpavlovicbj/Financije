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
        public int StoreId { get; set; }

        [Required]
        [MaxLength(50)]
        public string StoreName { get; set; }

        [Required]
        [MaxLength(50)]
        public string StoreNameUC { get; set; }

        [MaxLength(50)]
        public string StoreNameAccount { get; set; }

        public virtual List<Accounts> Accounts { get; set; }

        public virtual List<LinksArtDes> LinksArtDes { get; set; }
    }
}
