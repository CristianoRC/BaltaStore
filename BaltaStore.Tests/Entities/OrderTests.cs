using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Order _order;
        private Customer _customer;

        private Product _mouse;
        private Product _teclado;
        private Product _Fone;
        private Product _monitor;

        public OrderTests()
        {
            var name = new Name("Cristiano", "Cunha");
            var email = new Email("contato@cristianoprogramador.com");
            var document = new Document("49063872178");
            var customer = new Customer(name, email, document, "46848464868");

            _order = new Order(customer);

            _monitor = new Product("Monitor", "Monitor LCD", "./monitor.png", 159.90m, 15);
            _mouse = new Product("Mouse", "Mouse s/ fio", "./mouse.png", 99, 10);
            _Fone = new Product("Fone", "Fone USB", "./fone.png", 210, 15);
            _teclado = new Product("Teclado", "Teclado mecânico", "./teclado.png", 45, 5);
        }

        [TestMethod]
        public void ConsigoCriarUmNovoPedido()
        {
            Assert.IsTrue(_order.Valid);
        }

        [TestMethod]
        public void AoCriarUmNovoPedidoStatusDeveSerCriado()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        [TestMethod]
        public void RetornaDoisAoAdicionarDoisItensValidos()
        {
            _order.AddItem(_mouse, 5);
            _order.AddItem(_teclado, 2);

            Assert.AreEqual(2, _order.Items.Count);
        }

        [TestMethod]
        public void DeveRetornarCincoQuandoCompradoCincoItens()
        {
            _order.AddItem(_mouse, 5);

            Assert.AreEqual(5, _mouse.QuantityOnHand);
        }

        [TestMethod]
        public void DeveRetornarUmNumeroAoGerarUmPedido()
        {
            _order.Place();

            Assert.AreNotEqual(string.Empty, _order.Number);
        }

        [TestMethod]
        public void DeveRetornarPagoQuandoOPedidoForPago()
        {
            _order.Pay();

            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        [TestMethod]
        public void DeveRetornarDoisQuandoComprarDezProdutos()
        {
            _order.AddItem(_mouse, 5);
            _order.AddItem(_teclado, 2);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_teclado, 2);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_teclado, 2);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_teclado, 2);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_teclado, 2);

            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        [TestMethod]
        public void DeveRetornarCanceladoAoCancelarPedido()
        {
            _order.Cancel();

            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        [TestMethod]
        public void DeveCancelarEntregasAoCancelarPedido()
        {
            foreach (var item in _order.Deliveries)
            {
                Assert.AreEqual(EOrderStatus.Canceled, item.Status);
            }
        }
    }
}