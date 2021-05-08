using Financije.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financije.Presentation.Models.Financije
{
    public class AccountViewModel 
    {
        public List<AccountPreviewModel> Accounts { get; set; }

        public IList<Stores> StoresList { get; set; }

        public IList<Descriptions> DescriptionsList { get; set; }
    }
}
