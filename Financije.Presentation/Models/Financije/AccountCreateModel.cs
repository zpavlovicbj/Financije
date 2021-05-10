using Financije.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financije.Presentation.Models.Financije
{
    public class AccountCreateModel 
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Potrebno je unesti broj računa!")]
        [Display(Name = "Broj računa")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Potrebno je odabrati trgovinu!")]
        [Display(Name = "Trgovina")]
        public string Store { get; set; }

        public IList<Stores> StoresList { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        public IList<Descriptions> DescriptionsList { get; set; }

        [Display(Name = "Artikl")]
        public string Article { get; set; }

        public IList<Articles> ArticleList { get; set; }

        [Display(Name = "Isplata")]
        public double Payout { get; set; }

        [Display(Name = "Uplata")]
        public double Payin { get; set; }

        public double Price { get; set; }
    }
}
