namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Email
    {
        public Email(string adress)
        {
            Address = adress;
        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}