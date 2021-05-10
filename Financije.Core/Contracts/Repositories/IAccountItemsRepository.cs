using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Entities;
using System.Collections.Generic;

namespace Financije.Core.Contracts.Repositories
{
    public interface IAccountItemsRepository
    {
        List<AccountItem> GetAll();

        List<AccountItem> GetAll(int accountId);

        PagedRResult<AccountItem> GetPaginatedResult(PagedRQuery request, int id);

        AccountItem GetById(int id);

        int Count();

        int Count(int accountId);

        void Add(AccountItem name);

        void Edit();

        void Remove(int id);

        double SumById(int id);
    }
}
