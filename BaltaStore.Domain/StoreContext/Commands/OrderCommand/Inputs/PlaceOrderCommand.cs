using System;
using System.Collections.Generic;
using BaltaStore.Shered.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.StoreContext.OrderCommand.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemsCommand>();
        }
        public Guid IDCustomer { get; set; }
        public IList<OrderItemsCommand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new Contract()
            .HasLen(IDCustomer.ToString(),36,"Customer","ID do cliente inválido")
            .IsGreaterThan(OrderItems.Count,0,"OrderItems","Nenhum item no pedido"));

            return Valid();
        }
    }

    public class OrderItemsCommand
    {
        public Guid Product { get; set; }
        public Decimal Quantity { get; set; }
    }
}