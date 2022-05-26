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
        public void TestContactInformationEditForm()
        {
            ContractData fromTable =  app.Contract.GetContactInformationFromTable(0);
            ContractData fromForm = app.Contract.GetContactInformationFromEditForm(0,1);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromForm.AllEmails, fromForm.AllEmails);

            app.Auth.LogOut();
        }

        [Test]
        public void TestContactInformationDetielsForm()
        {
            ContractData fromEditForm = app.Contract.GetContactInformationFromEditForm(1,0);
            ContractData fromDetailsForm = app.Contract.GetContactInformationFromDetails(1);

            //Assert.AreEqual(fromEditForm, fromDetailsForm);
            Assert.AreEqual(fromEditForm.Alldetails, fromDetailsForm.Alldetails);
            app.Auth.LogOut();



        }
    }
}
