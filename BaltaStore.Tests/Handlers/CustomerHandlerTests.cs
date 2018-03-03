using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Handlers
{
    [TestClass]

    public class CustomerHandlerTests
    {
        [TestMethod]
        public void DeveRegistrarOClienteQuandoOCommandForValido()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Cristiano";
            command.LastName = "Cunha";
            command.Document = "03552114599";
            command.Email = "contato@cristianoprogramador.com";
            command.Phone = "199389798";

            var customerHandler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = customerHandler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, customerHandler.Valid);
        }
    }
}