using Financije.Core.Contracts.Repositories;
using Financije.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financije.Core.Contracts.Services
{
    public interface IFinancijeService
    {
        List<Stores> GetAll();

        int Count();

        void Remove(int id);

        void Add(string storeName);
    }
}
