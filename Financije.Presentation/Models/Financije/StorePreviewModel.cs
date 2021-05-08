using System.ComponentModel.DataAnnotations;

namespace Financije.Presentation.Models.Financije
{
    public class StorePreviewModel
    {
        public int StoreId { get; set; }

        [Required]
        [Display(Name = "Trgovina")]
        public string StoreName { get; set; }

        [Display(Name = "Trgovina s računa")]
        public string StoreNameAccount { get; set; }
    }
}
