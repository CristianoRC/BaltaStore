using System;

namespace BaltaStore.Domain.StoreContext.Queries
{
    public class ListCustomerQueryResult
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Document { get; set; }

        public string Email { get; set; }
    }
}