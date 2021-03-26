using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Financije.Presentation.Models.Financije
{
    public class StoreViewModel
    {
        [Display(Name = "Id")]
        public int StoreId { get; set; }

        [Required(ErrorMessage ="Potrebno je unesti naziv.")]
        [Display(Name = "Naziv")]
        public string StoreName { get; set; }

        public List<StorePreviewModel> StoreList { get; set; }

        //public List<int> ListPageSize { get; set; }
    }
}
