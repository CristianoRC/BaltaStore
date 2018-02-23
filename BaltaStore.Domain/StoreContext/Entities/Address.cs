using BaltaStore.Domain.StoreContext.Enums;
using Flunt.Notifications;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Address : Notifiable
    {
        public Address(
            string street,
            string number,
            string complement,
            string city,
            string state,
            string country,
            string zipCode,
            EAddressType addressType)
        {
            Street = street;
            Number = number;
            Complement = complement;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            AddressType = addressType;
        }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public EAddressType AddressType { get; private set; }

        public override string ToString()
        {
            return $"{Street}, {Number}  {City}/{State} {Country}";
        }
    }
}