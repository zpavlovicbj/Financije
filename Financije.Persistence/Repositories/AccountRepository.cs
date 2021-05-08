using Financije.Core.Contracts.Repositories;
using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Financije.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FinancijeContext _context;

        public AccountRepository(FinancijeContext context)
        {
            _context = context;
        }
        public void Add(Accounts name)
        {
            _context.Accounts.Add(name);
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Accounts.Count();
        }

        public void Edit()
        {
            _context.SaveChanges();
        }

        public List<Accounts> GetAll()
        {
            return _context.Accounts.Include(s => s.Store)
                                    .Include(d => d.Description)
                                    .OrderBy(o => o.Date).ToList();

        }

        public Accounts GetById(int id)
        {
            return _context.Accounts.Include(s => s.Store)
                                    .Include(d => d.Description)
                                    .SingleOrDefault(a => a.AccountId == id);
        }

        public Accounts GetByName(string accountNumber)
        {
            return _context.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
        }

        public int GetLastId()
        {
            var items = _context.Accounts.Include(s => s.Store).OrderBy(o => o.AccountId).ToList();
            return items[^1].AccountId;
        }

        public string GetLastUnmber()
        {
            throw new NotImplementedException();
        }

        public PagedRResult<Accounts> GetPaginatedResult(PagedRQuery request)
        {
            IQueryable<Accounts> query = _context.Accounts;

            if (!(string.IsNullOrEmpty(request.Columns.FirstOrDefault().Name) && string.IsNullOrEmpty(request.Order.FirstOrDefault().Dir)))
            {
                query = query.OrderBy(request.Columns.FirstOrDefault().Name + " " + request.Order.FirstOrDefault().Dir);
            }
            if (!string.IsNullOrEmpty(request.Search.Value))
            {
                query = query.Where(m => m.AccountNumber.ToLower().Contains(request.Search.Value.ToLower()));
                //|| m.Description.ToString().Contains(request.Search.Value.ToLower()));
            }

            int recordsTotal = query.Count();

            var data = query.Skip(request.Start).Take(request.Length).Include(d => d.Description).Include(d => d.Store).OrderBy(o => o.Date).ToList();
            

            return new PagedRResult<Accounts>
            {
                Count = recordsTotal,
                Items = data
            };
        }

        public void Remove(int id)
        {
            Accounts accounts = _context.Accounts.SingleOrDefault(a => a.AccountId == id);
            _context.Accounts.Remove(accounts);                       
            _context.SaveChanges();
        }
    }
}
