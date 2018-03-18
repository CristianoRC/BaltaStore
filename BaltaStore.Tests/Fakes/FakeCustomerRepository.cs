using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;

namespace BaltaStore.Tests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Delet(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return null;
        }

        public ListCustomerQueryResult Get(Guid id)
        {
            return null;
        }

        public IEnumerable<CustomerOrdersQuery> GetOrders(Guid id)
        {
            return null;
        }

        public void Save(Customer customer)
        {

        }

        public void Save(Customer customer, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}