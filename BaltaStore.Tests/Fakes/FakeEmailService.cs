using BaltaStore.Domain.StoreContext.Services;

namespace BaltaStore.Tests.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public void send(string to, string from, string subject, string body)
        {
            
        }
    }
}