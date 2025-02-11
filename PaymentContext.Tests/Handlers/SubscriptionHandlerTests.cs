using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler();
        }
    }
}