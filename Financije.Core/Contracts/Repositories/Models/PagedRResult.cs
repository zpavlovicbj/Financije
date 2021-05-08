using System.Collections.Generic;

namespace Financije.Core.Contracts.Repositories.Models
{
    public class PagedRResult<T>
    {
        public List<T> Items { get; set; }
        public int Count { get; set; }
    }
}
