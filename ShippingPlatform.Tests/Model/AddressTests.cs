using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Tests.Model
{
    [TestFixture]
    class AddressTests
    {

        [SetUp]
        public void Prepare()
        {

        }

        [Test]
        public void ConstructorTest()
        {
            // no guarantee of the order of unit tests, they are run in parallel
            //always check only one functionality in one test! if more constructors, add another tests for each
            Address address = new Address();
            Assert.IsNotNull(address.country, "country is null");
            Assert.IsNotNull(address.city, "city is null");
            Assert.IsNotNull(address.housenumber, "housenumber is null");
            Assert.IsNotNull(address.street, "street is null");
            Assert.IsNotNull(address.zipcode, "zipcode is null");
        }

      //  [TearDown] does stuff after executing
       
    }
}
