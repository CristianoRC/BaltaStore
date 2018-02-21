using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Pessoal
            var name = new Name("Cristiano", "Cunha");
            var document = new Document("9474-6494");
            var email = new Email("contato@cristianoprogramador.com");
            var customer = new Customer(name, email, document, "+55 (99) 999-999");

            //Produtos
            var mouse = new Product("Mouse", "Mouse c/ fio", "./mouse.png", 25m, 50m);
            var mouseSemFio = new Product("Mouse sem fio", "Mouse s/ fio", "./mouseSemFio.png", 50m, 30m);

            //Pedido
            var order = new Order(customer);
            order.AddItem(new OrderItem(mouse, 1));
            order.AddItem(new OrderItem(mouseSemFio, 3));

            //Gerar o pedido
            order.Place();

            if (order.Valid)
            {
                //Pagamento
                order.Pay();

                //Envio
                order.Ship();
            }


            //Cancelamento;
            order.Cancel();
        }
    }
}
