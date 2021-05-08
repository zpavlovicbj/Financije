using System.Collections.Generic;

namespace Financije.Presentation.Models.Financije
{
    public class DatatableViewModel<T>
    {
        public int Draw { get; set; }

        public int RecordsFiltered { get; set; }

        public int RecordsTotal { get; set; }

        public List<T> Data { get; set; }
    }
}
