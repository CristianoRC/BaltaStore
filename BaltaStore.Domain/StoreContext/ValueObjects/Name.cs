using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
            .HasMaxLen("Primeiro nome", 2, "firstName", "Nome inválido")
            .HasMinLen("Sobrenome", 2, "lastname", "Sobrenome inválido"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}