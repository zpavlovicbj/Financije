using System.ComponentModel.DataAnnotations;

namespace Financije.Presentation.Models.Financije
{
    public class StorePreviewModel
    {
        public int StoreId { get; set; }

        [Required]
        [Display(Name = "Platitelj/Primatelj")]
        public string StoreName { get; set; }
    }
}
