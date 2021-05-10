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
        void AddAccount(Accounts account);

        void AddAccountDetail(Accounts account);

        void AddAcountItem(AccountItemRModel accountItems);

        void AddArticles(string Name, int descriptionId);

        void AddDescription(string Name);

        void AddStore(string Name);


        int CountAccounts();

        int CountAcountItem();

        int CountAcountItem(int accountId);

        int CountArticles();

        int CountDescriptions();

        int CountStores();


        void EditAccount();

        void EditArticle();

        void EditDescription();

        void EditStore();


        List<Accounts> GetAllAccounts();

        List<AccountItem> GetAccountItemsByAccountId(int accountId); 

        List<Articles> GetAllArticles();

        List<Descriptions> GetAllDescriptions();

        List<Stores> GetAllStores();


        Accounts GetAccountsById(int id);

        AccountItem GetAccountItemById(int id);

        Articles GetArticlesById(int id);

        Descriptions GetDescriptionById(int id);

        Stores GetStoreById(int id);


        Accounts GetAccountsByName(string name);

        Articles GetArticlesByName(string name);

        Descriptions GetDescriptionByName(string name);

        Stores GetStoreByName(string name);


        PagedRResult<Accounts> SearchAccounts(PagedRQuery query);

        PagedRResult<AccountItem> SearchAccountItems(PagedRQuery query, int id);

        PagedRResult<Articles> SearchArticles(PagedRQuery query);

        PagedRResult<Descriptions> SearchDescriptions(PagedRQuery query);

        PagedRResult<Stores> SearchStores(PagedRQuery query);


        void RemoveAccount(int id);

        void RemoveAccountItem(int id);

        void RemoveArticles(int id);

        void RemoveDescription(int id);

        void RemoveStore(int id);

        int GetLastAccountId();

        double TotalAccountItems(int id);
    }
}
