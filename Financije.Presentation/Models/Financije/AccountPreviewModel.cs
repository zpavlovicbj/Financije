using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financije.Presentation.Models.Financije
{
    public class AccountPreviewModel
    {
        public int AccountId { get; set; }

        public string Date { get; set; }

        public string AccountNumber { get; set; }

        public int StoreId { get; set; }

        public string StoreName { get; set; }
        
        public int DescriptionId { get; set; }

        public string DescriptionName { get; set; }

        public string Payout { get; set; }

        public string Payin { get; set; }

        public int Month { get; set; }

        public int DetailsCount { get; set; }
    }
}
