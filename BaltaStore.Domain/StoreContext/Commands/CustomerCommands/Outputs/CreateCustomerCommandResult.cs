using System;
using BaltaStore.Shered.Commands;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult(bool sucess, string message, object data)
        {
            this.Sucess = sucess;
            this.Message = message;
            this.Data = data;

        }
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}