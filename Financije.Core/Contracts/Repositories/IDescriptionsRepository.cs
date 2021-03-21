using Financije.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financije.Core.Contracts.Repositories
{
    public interface IDescriptionsRepository
    {
        List<Descriptions> GetAll();

        (List<Descriptions> items, int count) GetPaginatedResult(int page, int size);

        Descriptions GetById(int id);

        Descriptions GetByMane(string name);

        int Count();

        void Add(Descriptions name);

        void Edit();

        void Remove(int id);
    }
}
