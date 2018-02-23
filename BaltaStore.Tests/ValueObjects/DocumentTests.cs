using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltaStore.Domain.StoreContext.ValueObjects;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document documentoValido;
        private Document documentoInalido;

        public DocumentTests()
        {
            documentoValido = new Document("81431631728");
            documentoInalido = new Document("814316311728");
        }


        [TestMethod]
        public void NaoDeveRetornarNotivacaoDocumentoValido()
        {
            Assert.IsTrue(documentoValido.Valid);
            Assert.AreEqual(0, documentoValido.Notifications.Count);
        }


        [TestMethod]
        public void DeveRetornarUmaNotificacaoQuandoODocumentoNaoForValido()
        {
            Assert.IsFalse(documentoInalido.Valid);
            Assert.AreNotEqual(0, documentoInalido.Notifications.Count);
        }
    }
}