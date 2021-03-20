using Financije.Core.Contracts.Repositories;
using Financije.Core.Contracts.Services;
using Financije.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financije.Service.Services
{
    public class FinancijeService : IFinancijeService
    {
        private readonly IStoreRepository _storeRepository;

        public FinancijeService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public void Add(string storeName)
        {
            var store = new Stores();
            store.StoreName = storeName;
            _storeRepository.Add(store);

        }

        public int Count()
        {
            return _storeRepository.Count();
        }

        public List<Stores> GetAll()
        {
            return _storeRepository.GetAll();
        }

        public void Remove(int id)
        {
            _storeRepository.Remove(id);
        }
    }
}
