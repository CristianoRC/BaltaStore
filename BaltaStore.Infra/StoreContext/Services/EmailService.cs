using BaltaStore.Domain.StoreContext.Services;

namespace BaltaStore.Infra.StoreContext.Services
{
    public class EmailService : IEmailService
    {
        public void send(string to, string from, string subject, string body)
        {
            //TODO: Implementar sistema de envio de e-mail
        }
    }
}