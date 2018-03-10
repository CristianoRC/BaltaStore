using System.Data;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.DataContexts;
using Dapper;

namespace BaltaStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BaltaDataContext _dataContext;

        public CustomerRepository(BaltaDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CheckDocument(string document)
        {
            return _dataContext.Connection.QueryFirst<bool>
                    ("select CheckDocument(@document)",
                      document);
        }

        public bool CheckEmail(string email)
        {
            return _dataContext.Connection.QueryFirst<bool>
                    ("select CheckEmail(@email)",
                      email);
        }

        public void Save(Customer customer)
        {
            _dataContext.Connection.Execute(@"select createcustomer(@ID,@fistName,
                                            @lastName,@document,@email,@phone)",
                new
                {
                    ID = customer.Id,
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
                    id = addresTemp.Id,
                    idcustomer = customer.Id,
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
    }
}