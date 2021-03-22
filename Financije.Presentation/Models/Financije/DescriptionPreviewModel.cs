using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financije.Presentation.Models.Financije
{
    public class DescriptionPreviewModel
    {
        public int DescriptionId { get; set; }

        [Required]
        [Display(Name = "Opis")]
        public string DescriptionName { get; set; }

        public int CurrentPage { get; set; }
    }
}
