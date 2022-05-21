using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressBookWebTests
{
    [TestFixture]
    public class ContractInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContractData fromTable =  app.Contract.GetContactInformationFromTable(0);
            ContractData fromForm = app.Contract.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromForm.AllEmails, fromForm.AllEmails);

            app.Auth.LogOut();
        }
    }
}
