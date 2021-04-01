using Financije.Core.Contracts.Repositories;
using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Contracts.Services;
using Financije.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financije.Service.Services
{
    public class FinancijeService : IFinancijeService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IDescriptionsRepository _descriptionsRepository;
        private readonly IStoreRepository _storeRepository;

        public FinancijeService(IArticleRepository articleRepository,
                                IDescriptionsRepository descriptionsRepository, 
                                IStoreRepository storeRepository)
        {
            _articleRepository = articleRepository;
            _descriptionsRepository = descriptionsRepository;
            _storeRepository = storeRepository;
        }

        public void AddArticles(string articleName, int descriptionId)
        {
            var article = new Articles();
            article.ArticleName = articleName;
            article.DescriptionId = descriptionId;
            _articleRepository.Add(article);
        }

        public void AddDescription(string descriptionName)
        {
            var description = new Descriptions();
            description.DescriptionName = descriptionName;
            _descriptionsRepository.Add(description);
        }

        public void AddStore(string storeName)
        {
            var store = new Stores();
            store.StoreName = storeName;
            _storeRepository.Add(store);
        }

        public int CountArticles()
        {
            return _articleRepository.Count();
        }

        public int CountDescriptions()
        {
            return _descriptionsRepository.Count();
        }

        public int CountStores()
        {
            return _storeRepository.Count();
        }

        public void EditArticle()
        {
            _articleRepository.Edit();
        }

        public void EditDescription()
        {
            _storeRepository.Edit();
        }

        public void EditStore()
        {
            _storeRepository.Edit();
        }

        public List<Articles> GetAllArticles()
        {
            return _articleRepository.GetAll();
        }

        public List<Descriptions> GetAllDescriptions()
        {
            return _descriptionsRepository.GetAll();
        }

        public List<Stores> GetAllStores()
        {
            return _storeRepository.GetAll();
        }

        public Articles GetArticlesById(int id)
        {
            var art = _articleRepository.GetById(id);
            return art;
        }

        public Articles GetArticlesByName(string name)
        {
            return _articleRepository.GetByNane(name);
        }

        public Descriptions GetDescriptionById(int id)
        {
            return _descriptionsRepository.GetById(id);
        }

        public Descriptions GetDescriptionByName(string name)
        {
            return _descriptionsRepository.GetByNane(name);
        }

        public Stores GetStoreById(int id)
        {
            return _storeRepository.GetById(id);
        }

        public Stores GetStoreByName(string name)
        {
            return _storeRepository.GetByNane(name);
        }

        public void RemoveArticles(int id)
        {
            _articleRepository.Remove(id);
        }

        public void RemoveDescription(int id)
        {
            _descriptionsRepository.Remove(id);
        }

        public void RemoveStore(int id)
        {
            _storeRepository.Remove(id);
        }

        public PagedRResult<Articles> SearchArticles(PagedRQuery query)
        {
            return _articleRepository.GetPaginatedResult(query);
        }

        public PagedRResult<Descriptions> SearchDescriptions(PagedRQuery query)
        {
            return _descriptionsRepository.GetPaginatedResult(query);
        }

        public PagedRResult<Stores> SearchStores(PagedRQuery query)
        {
            return _storeRepository.GetPaginatedResult(query);
        }
    }
}
