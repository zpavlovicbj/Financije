using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Financije.Presentation.Models.Financije
{
    public class StoreViewModel
    {
        [Required]
        [Display(Name = "Naziv")]
        public string StoreName { get; set; }

        public List<StorePreviewModel> StoreList { get; set; }
    }
}
