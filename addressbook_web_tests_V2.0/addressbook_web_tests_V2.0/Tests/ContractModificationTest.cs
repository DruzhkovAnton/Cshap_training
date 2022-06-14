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
                ContractData contract = new ContractData("NewContract", "xxx");
                contract.MiddleName = "ccc1";
                contract.Nickname = "vvv";
                contract.Title = "111";
                contract.Company = "222";
                contract.Address = "333";
                contract.PhoneHome = "44444";
                contract.Email = "5555";
                contract.Homepage = "www.jjjj.ru";
                app.Contract.Сreate(contract);
            }

            List<ContractData> oldContracts = ContractData.GetAll();

            app.Contract.Modify(0, newData);

            Assert.AreEqual(oldContracts.Count, app.Contract.GetContractCount());

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
