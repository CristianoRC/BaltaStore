using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string adress)
        {
            Address = adress;

            AddNotifications(new Contract()
            .IsEmail(Address, nameof(Address), "Email inválido"));
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}