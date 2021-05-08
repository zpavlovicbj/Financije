using Financije.Core.Contracts.Repositories;
using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Financije.Persistence.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly FinancijeContext _context;

        public ArticleRepository(FinancijeContext context)
        {
            _context = context;
        }

        public void Add(Articles article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Articles.Count();
        }

        public void Edit()
        {
            _context.SaveChanges();
        }

        public List<Articles> GetAll()
        {
            var article = _context.Articles.Include(d => d.Description).OrderBy(o => o.ArticleName).ToList();
            return article;
        }

        public Articles GetById(int id)
        {
            return _context.Articles.Include(d => d.Description).OrderBy(o => o.ArticleName).SingleOrDefault(a => a.ArticleId == id) ;
        }

        public Articles GetByName(string name)
        {
            return _context.Articles.SingleOrDefault(a => a.ArticleNameUC == name.ToUpper());
        }

        public PagedRResult<Articles> GetPaginatedResult(PagedRQuery request)
        {
            IQueryable<Articles> query = _context.Articles;

            if (!(string.IsNullOrEmpty(request.Columns.FirstOrDefault().Name) && string.IsNullOrEmpty(request.Order.FirstOrDefault().Dir)))
            {
                query = query.OrderBy(request.Columns.FirstOrDefault().Name + " " + request.Order.FirstOrDefault().Dir);
            }
            if (!string.IsNullOrEmpty(request.Search.Value))
            {
                query = query.Where(m => m.ArticleName.ToLower().Contains(request.Search.Value.ToLower()));
                                      //|| m.Description.ToString().Contains(request.Search.Value.ToLower()));
            }

            int recordsTotal = query.Count();

            var data = query.Skip(request.Start).Take(request.Length).Include(d => d.Description).OrderBy(o => o.ArticleName).ToList();

            return new PagedRResult<Articles>
            {
                Count = recordsTotal,
                Items = data
            };
        }

        public void Remove(int id)
        {
            Articles article = _context.Articles.SingleOrDefault(a => a.ArticleId == id);
            _context.Articles.Remove(article);
            _context.SaveChanges();
        }
    }
}
