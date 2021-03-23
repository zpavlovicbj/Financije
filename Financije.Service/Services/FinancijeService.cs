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
        private readonly IStoreRepository _storeRepository;
        private readonly IDescriptionsRepository _descriptionsRepository;

        public FinancijeService(IStoreRepository storeRepository, IDescriptionsRepository descriptionsRepository)
        {
            _storeRepository = storeRepository;
            _descriptionsRepository = descriptionsRepository;
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

        public int CountDescriptions()
        {
            return _descriptionsRepository.Count();
        }

        public int CountStores()
        {
            return _storeRepository.Count();
        }

        public void EditDescription()
        {
            _storeRepository.Edit();
        }

        public List<Descriptions> GetAllDescriptions()
        {
            return _descriptionsRepository.GetAll();
        }

        public List<Stores> GetAllStores()
        {
            return _storeRepository.GetAll();
        }

        public Descriptions GetDescriptionById(int id)
        {
            return _descriptionsRepository.GetById(id);
        }

        public Descriptions GetDescriptionByName(string name)
        {
            return _descriptionsRepository.GetByMane(name);
        }

        public (List<Descriptions> items, int count) GetPaginatedResultDescriptions(int page, int size)
        {
            throw new NotImplementedException();
        }

        public (List<Stores> items, int count) GetPaginatedResultStores(int page, int size)
        {
            throw new NotImplementedException();
        }

        /*public (List<Descriptions> items, int count) GetPaginatedResultDescriptions(int page, int size)
        {
           return _descriptionsRepository.GetPaginatedResult(page, size);
        }

        public (List<Stores> items, int count) GetPaginatedResultStores(int page, int size)
        {
            return _storeRepository.GetPaginatedResult(page, size);
        }*/

        public Stores GetStoreById(int id)
        {
            return _storeRepository.GetById(id);
        }

        public Stores GetStoreByName(string name)
        {
            return _storeRepository.GetByNane(name);
        }

        public void RemoveDescription(int id)
        {
            _descriptionsRepository.Remove(id);
        }

        public void RemoveStore(int id)
        {
            _storeRepository.Remove(id);
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
