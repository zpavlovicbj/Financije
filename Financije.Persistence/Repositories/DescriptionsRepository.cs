using Financije.Core.Contracts.Repositories;
using Financije.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public (List<Descriptions> items, int count) GetPaginatedResult(int page, int size)
        {
            var query = _context.Descriptions.AsSingleQuery().OrderBy(o => o.DescriptionName);

            int count = query.Count();

            var items = query.Skip(page).Take(size).ToList();

            return (items, count);
        }

        public void Remove(int id)
        {
            Descriptions descriptions = _context.Descriptions.SingleOrDefault(d => d.DescriptionId == id);
            _context.Remove(descriptions);
            _context.SaveChanges();
        }
    }
}
