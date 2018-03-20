using System;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
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

        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;


        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verificar se o CPF e Email já estão cadastrados;
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está cadastrado.");

            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este email já está cadastrado.");

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

            if (Invalid)//Se houver alguma broblema o Customer não gravado no banco
                return new CommandResult(false, "Erro ao cadastrar o cliente", Notifications);

            //Gravar o cliente  no banco;
            _repository.Save(customer);

            //Enviar Email de boas vindas;
            _emailService.send(email.Address, "contato@cristianoprogramador.com",
                                "Bem vindo", "Cadastro realizado com sucesso");

            //Retornar o resultado para tela;
            return new CommandResult(true, "Cliente Cadastrado com Sucesso",
                new
                {
                    ID = customer.Id,
                    Name = customer.Name.ToString(),
                    Email = customer.Email
                });
        }

        public ICommandResult Handle(CreateCustomerCommand command, Guid id)
        {
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

            if (Invalid)//Se houver alguma broblema o Customer não gravado no banco
                return new CommandResult(false, "Erro ao cadastrar o cliente", Notifications);

            //Gravar o cliente  no banco;
            _repository.Save(customer, id);

            //Enviar Email de boas vindas;
            _emailService.send(email.Address, "contato@cristianoprogramador.com",
                                "Atualização de cadastro", "Cadastro atualizado com sucesso");

            //Retornar o resultado para tela;
            return new CommandResult(true, "Cadastro atualizado com Sucesso",
                new
                {
                    ID = customer.Id,
                    Name = customer.Name.ToString(),
                    Email = customer.Email
                });
        }


        public void Delet(Guid ID)
        {
            _repository.Delet(ID);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}