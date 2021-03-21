using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Financije.Presentation.Models.Financije
{
    public class StoreViewModel
    {
        public int StoresId { get; set; }

        [Required(ErrorMessage ="Potrebno je unesti naziv.")]
        [Display(Name = "Naziv")]
        public string StoreName { get; set; }

        public List<StorePreviewModel> StoreList { get; set; }

        public Page<StorePreviewModel> Page { get; set; }

        public int PageCount { get; set; }

        public List<int> ListPageSize { get; set; }
    }
}
