using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Entities;
using System.Collections.Generic;

namespace Financije.Core.Contracts.Repositories
{
    public interface IDescriptionsRepository
    {
        List<Descriptions> GetAll();

        PagedRResult<Descriptions> GetPaginatedResult(PagedRQuery request);

        //(List<Descriptions> items, int count) GetPaginatedResult(int page, int size);

        Descriptions GetById(int id);

        Descriptions GetByMane(string name);

        int Count();

        void Add(Descriptions name);

        void Edit();

        void Remove(int id);
    }
}
