using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financije.Presentation.Models.Financije
{
    public class AccountDetailsModel
    {
        public int Id { get; set; }

        public DateTime AccountDate { get; set; }

        public string AccountNumber { get; set; }

        public string Store { get; set; }

        public string Article { get; set; }

        public string Description { get; set; }

        public double Payout { get; set; }

        public double Payin { get; set; }
    }
}
