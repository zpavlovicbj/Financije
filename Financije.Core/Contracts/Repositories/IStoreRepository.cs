using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Entities;
using System.Collections.Generic;

namespace Financije.Core.Contracts.Repositories
{
    public interface IStoreRepository
    {
        List<Stores> GetAll();

        PagedRResult<Stores> GetPaginatedResult(PagedRQuery request);

        Stores GetById(int id);

        Stores GetByName(string name);

        int Count();

        void Add(Stores name);

        void Edit();

        void Remove(int id);
    }
}
