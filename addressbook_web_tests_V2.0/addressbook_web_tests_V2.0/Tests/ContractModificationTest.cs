using NUnit.Framework;
using System.Collections.Generic;

namespace addressBookWebTests
{
    [TestFixture]
    public class ContractModifitationTests : AuthTestBase
    {
        [Test]
        public void ContractModificationTest()
        {

            ContractData newData = new ContractData("ModifyContract", "xxx");
            newData.MiddleName = "ccc1";
            newData.Nickname = "vvv";
            newData.Title = "111";
            newData.Company = "222";
            newData.Address = "333";
            newData.PhoneHome = "44444";
            newData.Email = "5555";
            newData.Homepage = "www.jjjj.ru";

            if (app.Contract.IsContractCreate(2))
            {

                app.Contract.Сreate(newData);
            }

            List<ContractData> oldContracts = ContractData.GetAll();

            app.Contract.Modify(oldContracts[0], newData);

            Assert.AreEqual(oldContracts.Count, ContractData.GetAll().Count);

            List<ContractData> newContracts = ContractData.GetAll();
            oldContracts[0].FirstName = newData.FirstName;
            oldContracts[0].Lastname = newData.Lastname;
            oldContracts.Sort();
            newContracts.Sort();
            Assert.AreEqual(oldContracts, newContracts);

            //app.Auth.LogOut();
        }

    }
}
