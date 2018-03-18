using System;
using System.Collections.Generic;
using System.Data;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.DataContexts;
using Dapper;

namespace BaltaStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private BaltaDataContext _dataContext;

        public CustomerRepository(BaltaDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CheckDocument(string document)
        {
            return _dataContext.Connection.QueryFirst<bool>
                    ("select CheckDocument(@document)",
                      new { document = document });
        }

        public bool CheckEmail(string email)
        {
            return _dataContext.Connection.QueryFirst<bool>
                    ("select CheckEmail(@email)",
                      new { email = email });
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _dataContext.Connection.Query<ListCustomerQueryResult>
            ("select * from public.QueryCutomers");
        }

        public ListCustomerQueryResult Get(Guid id)
        {
            var sql = @"SELECT customer.id,
                    ((customer.firstname)::text || ' ' || (customer.lastname)::text) AS name,
                    customer.document,customer.email
                    FROM customer where id = @id";

            return _dataContext.Connection.QueryFirst<ListCustomerQueryResult>(sql,
                                                        new { id = id.ToString() });
        }

        public IEnumerable<CustomerOrdersQuery> GetOrders(Guid id)
        {
            var sql = @"";

            return _dataContext.Connection.Query<CustomerOrdersQuery>(sql,
                                                        new { id = id.ToString() });
        }

        public void Save(Customer customer)
        {
            _dataContext.Connection.Execute(@"insert into customer values(@ID,@fistName,
                                                @lastName,@document,@email,@phone)",
                new
                {
                    ID = customer.Id.ToString(),
                    fistName = customer.Name.FirstName,
                    lastName = customer.Name.LastName,
                    document = customer.Document.Number,
                    email = customer.Email.Address,
                    phone = customer.Phone
                });

            foreach (var addresTemp in customer.Addresses)
            {
                _dataContext.Connection.Execute(@"selec createcustomer(@ID,IDCustomer,@street,@number,
                                    @complement,@city,@state,@country,@zipcode,@type)",
                new
                {
                    ID = addresTemp.Id,
                    IDCustomer = customer.Id,
                    street = addresTemp.Street,
                    number = addresTemp.Number,
                    complement = addresTemp.Complement,
                    city = addresTemp.City,
                    state = addresTemp.State,
                    country = addresTemp.Country,
                    zipcode = addresTemp.ZipCode,
                    type = addresTemp.Type
                });
            }
        }

        public void Save(Customer customer, Guid id)
        {
            _dataContext.Connection.Execute(@"update customer set firstName = @fistName,
                                            lastName = @lastName,
                                            document = @document,
                                            email = @email,
                                            phone = @phone where ID = @ID",
                new
                {
                    ID = id.ToString(),
                    fistName = customer.Name.FirstName,
                    lastName = customer.Name.LastName,
                    document = customer.Document.Number,
                    email = customer.Email.Address,
                    phone = customer.Phone
                });
        }

        public void Delet(Guid id)
        {
            _dataContext.Connection.Execute("delete from customer where id = @id",
                new { id = id.ToString() });
        }
    }
}