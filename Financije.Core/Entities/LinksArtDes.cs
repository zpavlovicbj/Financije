using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Financije.Core.Entities
{
    public class LinksArtDes
    {
        public int Id { get; set; }

        [Required]
        public int DescriptionId { get; set; }

        public virtual Descriptions Description { get; set; }

        [Required]
        public int StoreId { get; set; }
        public virtual Stores Stores { get; set; }
    }
}
