using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;

namespace BaltaStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        IEnumerable<ListCustomerQueryResult> Get();
        ListCustomerQueryResult Get(Guid id);

        IEnumerable<CustomerOrdersQuery> GetOrders(Guid id);
    }
}