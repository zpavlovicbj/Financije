using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Entities;
using System.Collections.Generic;

namespace Financije.Core.Contracts.Repositories
{
    public interface IAccountItemsRepository
    {
        List<AccountItems> GetAll();

        List<AccountItems> GetAll(int accountId);

        PagedRResult<AccountItems> GetPaginatedResult(PagedRQuery request, int id);

        AccountItems GetById(int id);

        List<AccountItems> GetByAccountId(int accountId);

        int Count();

        int Count(int accountId);

        void Add(AccountItems name);

        void Edit();

        void Remove(int id);

        void RemoveByAccountId(int accountId);

    }
}
