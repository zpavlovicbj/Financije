using System.ComponentModel.DataAnnotations;

namespace Financije.Presentation.Models.Financije
{
    public class DescriptionPreviewModel
    {
        public int DescriptionId { get; set; }

        [Required]
        [Display(Name = "Opis")]
        public string DescriptionName { get; set; }

        //public int CurrentPage { get; set; }
    }
}
