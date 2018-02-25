using System;
using BaltaStore.Shered.Commands;
using Flunt.Notifications;

namespace BaltaStore.Domain.StoreContext.CustomerCommands.Inputs
{
    public class AddAddressCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public Enums.EAddressType Type { get; set; }

        bool ICommand.Valid()
        {
            return Valid;
        }
    }
}