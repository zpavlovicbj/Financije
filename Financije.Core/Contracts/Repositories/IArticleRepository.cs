using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financije.Core.Contracts.Repositories
{
    public interface IArticleRepository
    {
        List<Articles> GetAll();

        PagedRResult<Articles> GetPaginatedResult(PagedRQuery request);

        Articles GetById(int id);

        Articles GetByName(string name);

        int Count();

        void Add(Articles article);

        void Edit();

        void Remove(int id);
    }
}
