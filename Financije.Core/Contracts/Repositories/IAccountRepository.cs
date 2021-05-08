using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financije.Core.Contracts.Repositories
{
    public interface IAccountRepository
    {
        List<Accounts> GetAll();

        PagedRResult<Accounts> GetPaginatedResult(PagedRQuery request);

        Accounts GetById(int id);

        Accounts GetByName(string name);

        int Count();

        void Add(Accounts name);

        void Edit();

        void Remove(int id);

        string GetLastUnmber();

        int GetLastId();
    }
}
