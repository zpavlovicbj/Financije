using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financije.Presentation.Models.Financije
{
    public class ArticleViewModel
    {
        public int ArticleId { get; set; }

        public string Name { get; set; }

        public List<ArticlePreviewModel> ArticlesList { get; set; }
    }
}
