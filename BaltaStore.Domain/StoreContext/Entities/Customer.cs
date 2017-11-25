using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.ValueObjects;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer
    {
        private readonly IList<Address> _addresses;
        public Customer(
            Name name,
            Email email,
            Document document,
            string phone)
        {
            Name = name;
            Email = email;
            Document = document;
            Phone = phone;
            _addresses = new List<Address>();
        }

        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }


        public override string ToString()
        {
            return Name.ToString();
        }
    }
}