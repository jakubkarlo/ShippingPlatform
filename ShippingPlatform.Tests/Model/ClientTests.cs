using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Tests
{
    [TestFixture]
    public class ClientTests
    {
        [Test]
        // [TestCase] - you can provide the values of the each test
        public void ConstructorTest()
        {
            Client client = new Client();
            Assert.IsNotNull(client.login);
            Assert.IsNotNull(client.password);
            Assert.IsNotNull(client.emailAddress);
            Assert.IsNotNull(client.clientAddress);
            Assert.IsNotNull(client.order);
        }

    }
}
