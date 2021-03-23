using Financije.Core.Contracts.Repositories;
using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Financije.Persistence.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly FinancijeContext _context;

        public StoreRepository(FinancijeContext context)
        {
            _context = context;
        }

        public void Add(Stores name)
        {
            _context.Stores.Add(name);
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Stores.Count();
        }

        public void Edit()
        {
            _context.SaveChanges();
        }

        public List<Stores> GetAll()
        {
            return _context.Stores.OrderBy(o => o.StoreName).ToList();
        }

        public Stores GetById(int id)
        {
            return _context.Stores.SingleOrDefault(c => c.StoresId == id);
        }

        public Stores GetByNane(string name)
        {
            return _context.Stores.SingleOrDefault(c => c.StoreName == name);
        }

        /*public (List<Stores> items, int count) GetPaginatedResult(int page, int size)
        {
            var query = _context.Stores.AsSingleQuery().OrderBy(o => o.StoreName);

            int count = query.Count();

            var items = query.Skip(page).Take(size).ToList();

            return (items, count);
        }*/

        public PagedRResult<Stores> GetPaginatedResult(PagedRQuery request)
        {
            IQueryable<Stores> query = _context.Stores;

            if (!(string.IsNullOrEmpty(request.Columns.FirstOrDefault().Name) && string.IsNullOrEmpty(request.Order.FirstOrDefault().Dir)))
            {
                query = query.OrderBy(request.Columns.FirstOrDefault().Name + " " + request.Order.FirstOrDefault().Dir);
            }
            if (!string.IsNullOrEmpty(request.Search.Value))
            {
                query = query.Where(m => m.StoreName.ToLower().Contains(request.Search.Value.ToLower()));
            }

            int recordsTotal = query.Count();

            var data = query.Skip(request.Start).Take(request.Length).ToList();

            return new PagedRResult<Stores>
            {
                Count = recordsTotal,
                Items = data
            };
        }

        public void Remove(int id)
        {
            Stores stores = _context.Stores.SingleOrDefault(s => s.StoresId == id);
            _context.Stores.Remove(stores);
            _context.SaveChanges();
        }
    }
}
