using Financije.Core.Contracts.Repositories;
using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Financije.Persistence.Repositories
{
    public class AccountItemsRepository : IAccountItemsRepository
    {
        private readonly FinancijeContext _context;

        public AccountItemsRepository(FinancijeContext context)
        {
            _context = context;
        }

        public void Add(AccountItem name)
        {
            _context.AccountItems.Add(name);
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.AccountItems.Count();
        }

        public int Count(int accountId)
        {
            return _context.AccountItems.Count(ai => ai.AccountId == accountId);
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public List<AccountItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<AccountItem> GetAll(int accountId)
        {
            throw new NotImplementedException();
        }

        public List<AccountItem> GetByAccountId(int accountId)
        {
            return _context.AccountItems.Where(i => i.AccountId == accountId).ToList();
        }

        public AccountItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public PagedRResult<AccountItem> GetPaginatedResult(PagedRQuery request, int id)
        {
            IQueryable<AccountItem> query = _context.AccountItems.Where(i => i.AccountId == id);

            int recordsTotal = query.Count();

            var data = query.Include(d => d.Article).ToList();


            return new PagedRResult<AccountItem>
            {
                Count = recordsTotal,
                Items = data
            };
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveByAccountId(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
