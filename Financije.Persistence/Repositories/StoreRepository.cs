using Financije.Core.Contracts.Repositories;
using Financije.Core.Entities;
using System.Collections.Generic;
using System.Linq;

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

        public Stores GetByMane(string name)
        {
            return _context.Stores.SingleOrDefault(c => c.StoreName == name);
        }

        public void Remove(int id)
        {
            Stores stores = _context.Stores.SingleOrDefault(s => s.StoresId == id);
            _context.Stores.Remove(stores);
            _context.SaveChanges();
        }
    }
}
