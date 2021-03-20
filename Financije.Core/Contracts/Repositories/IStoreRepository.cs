using Financije.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financije.Core.Contracts.Repositories
{
    public interface IStoreRepository
    {
        List<Stores> GetAll();

        Stores GetById(int id);

        Stores GetByMane(string name);

        int Count();

        void Add(Stores name);

        void Edit();

        void Remove(int id);
    }
}
