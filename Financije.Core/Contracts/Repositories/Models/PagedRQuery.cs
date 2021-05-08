using System.Collections.Generic;

namespace Financije.Core.Contracts.Repositories.Models
{
    public class PagedRQuery
    {
        public int Draw { get; set; }
        public List<ColumnRModel> Columns { get; set; }
        public List<OrderRModel> Order { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public SearchRModel Search { get; set; }
    }
}
