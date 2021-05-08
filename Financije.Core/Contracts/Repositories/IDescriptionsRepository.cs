using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Entities;
using System.Collections.Generic;

namespace Financije.Core.Contracts.Repositories
{
    public interface IDescriptionsRepository
    {
        List<Descriptions> GetAll();

        PagedRResult<Descriptions> GetPaginatedResult(PagedRQuery request);

        Descriptions GetById(int id);

        Descriptions GetByName(string name);

        int Count();

        void Add(Descriptions name);

        void Edit();

        void Remove(int id);
    }
}
