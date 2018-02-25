using System;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shered.Commands;
using Flunt.Notifications;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    //Fluxo do cadastro do cliente.
    public class CustomerHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verificar se o CPF e Email já estão cadastrados;

            //Criar os VO's e a Entidade;
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var document = new Document(command.Document);

            var customer = new Customer(name, email, document, command.Phone);

            //Validar Entidade e VO;
            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(customer.Notifications);

            //Gravar o cliente  no banco;

            //Enviar Email de boas vindas;

            //Retornar o resultado para tela;
            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);

        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}