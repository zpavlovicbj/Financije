using Financije.Core.Contracts.Repositories;
using Financije.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financije.Core.Contracts.Services
{
    public interface IFinancijeService
    {
        List<Descriptions> GetAllDescriptions();

        (List<Descriptions> items, int count) GetPaginatedResultDescriptions(int page, int size);

        int CountDescriptions();

        void RemoveDescription(int id);

        void AddDescription(string descriptionName);

        Descriptions GetDescriptionByName(string name);

        Descriptions GetDescriptionById(int id);


        List<Stores> GetAllStores();

        (List<Stores> items, int count) GetPaginatedResultStores(int page, int size);

        int CountStores();

        void RemoveStore(int id);

        void AddStore(string storeName);

        Stores GetStoreByName(string name);

        Stores GetStoreById(int id);
    }
}
