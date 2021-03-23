using Financije.Core.Contracts.Repositories;
using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Financije.Persistence.Repositories
{
    public class DescriptionsRepository : IDescriptionsRepository
    {
        private readonly FinancijeContext _context;

        public DescriptionsRepository(FinancijeContext context)
        {
            _context = context;
        }

        public void Add(Descriptions name)
        {
            _context.Descriptions.Add(name);
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Descriptions.Count();
        }

        public void Edit()
        {
            _context.SaveChanges();
        }

        public List<Descriptions> GetAll()
        {
            return _context.Descriptions.OrderBy(o => o.DescriptionName).ToList();
        }

        public Descriptions GetById(int id)
        {
            return _context.Descriptions.SingleOrDefault(d => d.DescriptionId == id);
        }

        public Descriptions GetByMane(string name)
        {
            return _context.Descriptions.SingleOrDefault(d => d.DescriptionName == name);
        }

        /*public (List<Descriptions> items, int count) GetPaginatedResult(int page, int size)
        {
            var query = _context.Descriptions.AsSingleQuery().OrderBy(o => o.DescriptionName);

            int count = query.Count();

            var items = query.Skip(page).Take(size).ToList();

            return (items, count);
        }*/

        public PagedRResult<Descriptions> GetPaginatedResult(PagedRQuery request)
        {
            IQueryable<Descriptions> query = _context.Descriptions;

            if (!(string.IsNullOrEmpty(request.Columns.FirstOrDefault().Name) && string.IsNullOrEmpty(request.Order.FirstOrDefault().Dir)))
            {
                query = query.OrderBy(request.Columns.FirstOrDefault().Name + " " + request.Order.FirstOrDefault().Dir);
            }
            if (!string.IsNullOrEmpty(request.Search.Value))
            {
                query = query.Where(m => m.DescriptionName.ToLower().Contains(request.Search.Value.ToLower()));
            }

            int recordsTotal = query.Count();

            var data = query.Skip(request.Start).Take(request.Length).ToList();

            return new PagedRResult<Descriptions>
            {
                Count = recordsTotal,
                Items = data
            };
        }

        public void Remove(int id)
        {
            Descriptions descriptions = _context.Descriptions.SingleOrDefault(d => d.DescriptionId == id);
            _context.Remove(descriptions);
            _context.SaveChanges();
        }
    }
}
