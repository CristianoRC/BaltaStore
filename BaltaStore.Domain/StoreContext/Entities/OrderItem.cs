using System.Collections.Generic;
using BaltaStore.Shered.Entities;
using Flunt.Notifications;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if (Product.QuantityOnHand < quantity)
                AddNotification("Quantity",
                $"Existe apenas {Product.QuantityOnHand} {Product.Title} em estoque.");

            product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        public IDictionary<string, string> Notification { get; private set; }
    }
}