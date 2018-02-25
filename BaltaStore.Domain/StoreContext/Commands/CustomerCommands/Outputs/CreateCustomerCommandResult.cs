using System;
using BaltaStore.Shered.Commands;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult() { }

        public CreateCustomerCommandResult(Guid iD, string name, string email)
        {
            this.ID = iD;
            this.Name = name;
            this.Email = email;

        }

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}