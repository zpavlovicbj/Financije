using Financije.Core.Contracts.Repositories;
using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financije.Core.Contracts.Services
{
    public interface IFinancijeService
    {
        List<Articles> GetAllArticles();

        PagedRResult<Articles> SearchArticles(PagedRQuery query);

        int CountArticles();

        void RemoveArticles(int id);

        void AddArticles(string descriptionName);

        Articles GetArticlesByName(string name);

        Articles GetArticlesById(int id);

        void EditArticle();

        PagedRResult<Descriptions> SearchDescriptions(PagedRQuery query);

        int CountDescriptions();

        void RemoveDescription(int id);

        void AddDescription(string descriptionName);

        Descriptions GetDescriptionByName(string name);

        Descriptions GetDescriptionById(int id);

        void EditDescription();

        PagedRResult<Stores> SearchStores(PagedRQuery query);

        int CountStores();

        void RemoveStore(int id);

        void AddStore(string storeName);

        Stores GetStoreByName(string name);

        Stores GetStoreById(int id);

        void EditStore();
    }
}
