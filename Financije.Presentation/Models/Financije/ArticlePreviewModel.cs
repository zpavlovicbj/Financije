using Financije.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financije.Presentation.Models.Financije
{
    public class ArticlePreviewModel
    {
        [Display(Name = "Id")]
        public int ArticleId { get; set; }

        [Display(Name = "Naziv artikla")]
        public string ArticleName { get; set; }

        [Display(Name = "Opis artikla")]
        public string DescriptionName { get; set; }

        public IList<Descriptions> DescriptionsList { get; set; }
    }
}
