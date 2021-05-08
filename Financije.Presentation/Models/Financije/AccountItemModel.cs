using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financije.Presentation.Models.Financije
{
    public class AccountItemModel
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public string Article { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
