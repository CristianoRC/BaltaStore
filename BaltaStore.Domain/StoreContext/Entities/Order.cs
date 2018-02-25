using System;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shered.Entities;
using Flunt.Notifications;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque.");

            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }

        //Criar um pedido
        public void Place()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();

            if (this.Items.Count == 0)
                AddNotification("Items",
                "Esse pedido não possui Itens");
        }

        //Pagar um pedidio
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        //Enviar um pedido
        public void Ship()
        {
            //A cada 5 produtos é uma entrega
            var deliveries = new List<Delivery>();
            
            var count = 1;

            //Divide as entrega a cada 5 item.
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(7)));
                    count = 1;
                }

                count++;
            }

            deliveries.ForEach(x => x.Ship()); // Percorre todas as entregas e manda entregar
            deliveries.ForEach(x => _deliveries.Add(x)); //Adiciona as entregas ao pedido
        }

        //Cancelar um pedido
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}