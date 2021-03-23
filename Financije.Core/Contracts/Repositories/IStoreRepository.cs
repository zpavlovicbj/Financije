using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Entities;
using System.Collections.Generic;

namespace Financije.Core.Contracts.Repositories
{
    public interface IStoreRepository
    {
        List<Stores> GetAll();

        PagedRResult<Stores> GetPaginatedResult(PagedRQuery request);

        //(List<Stores> items, int count) GetPaginatedResult(int page, int size);

        Stores GetById(int id);

        Stores GetByNane(string name);

        int Count();

        void Add(Stores name);

        void Edit();

        void Remove(int id);
    }
}
