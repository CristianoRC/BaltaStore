using BaltaStore.Shered.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.StoreContext.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable,ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        //FAIL FAST VALIDATION
        //Faz uma varredura inicial para evitar comunicações 
        //futuras no banco e processamento desnecessário
        public bool Validate()
        {
            AddNotifications(new Contract()
                        .HasMaxLen("Primeiro nome", 2, "firstName", "Nome inválido")
                        .HasMinLen("Sobrenome", 2, "lastname", "Sobrenome inválido")
                        .IsEmail(Email, "Email", "Email Inválido")
                        .HasLen(Document, 11, "Document", "CPF inválido"));

            return Valid;
        }
    }
}