using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Financije.Presentation.Models.Financije
{
    public class DescriptionViewModel
    {
        [Display(Name = "Id")]
        public int DescriptionId { get; set; }

        [Required(ErrorMessage = "Potrebno je unesti naziv.")]
        [Display(Name = "Naziv")]
        public string DescriptionName { get; set; }

        public List<DescriptionPreviewModel> DescriptionList { get; set; }

    }
}
