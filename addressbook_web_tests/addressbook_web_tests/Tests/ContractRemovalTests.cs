using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressBookWebTests.Tests
{
    [TestFixture]
    public class ContractRemovalTests : TestBase
    {
        [Test]
        public void ContractRemovalTest()
        {
            app.Contract.Removal(2);
            app.Auth.LogOut();
        }
    }
}
