using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Financije.Core.Entities
{
    public class Articles
    {
        [Key]
        [Required]
        public int ArticleId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ArticleName { get; set; }

        [Required]
        [MaxLength(50)]
        public string ArticleNameUC { get; set; }

        public int DescriptionId { get; set; }

        public virtual Descriptions Description { get; set; }

        public virtual List<AccountItem> AccountItems { get; set; }
    }
}
