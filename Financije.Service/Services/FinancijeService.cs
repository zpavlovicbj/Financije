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
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountItemsRepository _accountItemsRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IDescriptionsRepository _descriptionsRepository;
        private readonly IStoreRepository _storeRepository;

        public FinancijeService(IAccountRepository accountRepository,
                                IAccountItemsRepository accountItemsRepository,
                                IArticleRepository articleRepository,
                                IDescriptionsRepository descriptionsRepository, 
                                IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _accountItemsRepository = accountItemsRepository;
            _articleRepository = articleRepository;
            _descriptionsRepository = descriptionsRepository;
            _storeRepository = storeRepository;
        }

        public void AddAccount(Accounts account)
        {
            account.AccountNumber = GetAccountNumber();
            _accountRepository.Add(account);
        }

        void IFinancijeService.AddAccountDetail(Accounts account)
        {
            _accountRepository.Add(account);

        }

        public void AddAcountItem(AccountItem accountItems)
        {
            _accountItemsRepository.Add(accountItems);
        }

        public void AddArticles(string name, int descriptionId)
        {
            Articles article = new()
            {
                ArticleName = name,
                ArticleNameUC = name.ToUpper(),
                DescriptionId = descriptionId
            };
            _articleRepository.Add(article);
        }

        public void AddDescription(string name)
        {
            var description = new Descriptions
            {
                DescriptionName = name,
                DescriptionNameUC = name.ToUpper()
            };
            _descriptionsRepository.Add(description);
        }

        public void AddStore(string name)
        {
            var store = new Stores
            {
                StoreName = name,
                StoreNameUC = name.ToUpper()
            };
            _storeRepository.Add(store);
        }


        public int CountAccounts()
        {
            return _accountRepository.Count();
        }


        public int CountAcountItem()
        {
            return _accountItemsRepository.Count();
        }

        public int CountAcountItem(int accountId)
        {
            return _accountItemsRepository.Count(accountId);
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


        public void EditAccount()
        {
            _accountRepository.Edit();
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


        public Accounts GetAccountsById(int id)
        {
            return _accountRepository.GetById(id);
        }

        public Articles GetArticlesById(int id)
        {
            return _articleRepository.GetById(id); 
        }

        public Descriptions GetDescriptionById(int id)
        {
            return _descriptionsRepository.GetById(id);
        }

        public Stores GetStoreById(int id)
        {
            return _storeRepository.GetById(id);
        }


        public Accounts GetAccountsByName(string name)
        {
            return _accountRepository.GetByName(name);
        }

        public Articles GetArticlesByName(string name)
        {
            return _articleRepository.GetByName(name);
        }

        public Descriptions GetDescriptionByName(string name)
        {
            return _descriptionsRepository.GetByName(name);
        }

        public Stores GetStoreByName(string name)
        {
            return _storeRepository.GetByName(name);
        }


        public List<Accounts> GetAllAccounts()
        {
            return _accountRepository.GetAll();
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
                

        public void RemoveAccount(int id)
        {
            _accountRepository.Remove(id);
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

        public PagedRResult<Accounts> SearchAccounts(PagedRQuery query)
        {
            return _accountRepository.GetPaginatedResult(query);
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

        private string GetAccountNumber()
        {
            if (_accountRepository.Count() > 0)
            {
                List<int> accNumbers = new();
                foreach (var account in _accountRepository.GetAll())
                {
                    if (int.TryParse(account.AccountNumber, out int accNr))
                    {
                        accNumbers.Add(accNr);
                    }
                }

                if (accNumbers.Count > 0)
                {
                    accNumbers.Sort();
                    return (accNumbers[^1] + 1).ToString(); //Index operator
                }
            }
            return "1";
        }

        int IFinancijeService.GetLastAccountId()
        {
            return _accountRepository.GetLastId();
        }

        public List<AccountItem> GetAccountItemsByAccountId(int accountId)
        {
            return _accountItemsRepository.GetByAccountId(accountId);
        }

        public PagedRResult<AccountItem> SearchAccountItems(PagedRQuery query, int id)
        {
            return _accountItemsRepository.GetPaginatedResult(query, id);
        }
    }
}
