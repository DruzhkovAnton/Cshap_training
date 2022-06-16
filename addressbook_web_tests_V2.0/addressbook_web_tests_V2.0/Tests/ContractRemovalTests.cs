using NUnit.Framework;
using System.Collections.Generic;

namespace addressBookWebTests
{
    [TestFixture]
    public class ContractRemovalTests : AuthTestBase
    {
        [Test]
        public void ContractRemovalTest()
        {
            if (app.Contract.IsContractCreate(0))
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
            ContractData toBeRemoved = oldContracts[0];
            app.Contract.Remove(toBeRemoved);
            Assert.AreEqual(oldContracts.Count-1, app.Contract.GetContractCount());

            List<ContractData> newContracts = ContractData.GetAll();


            oldContracts.RemoveAt(0);
            Assert.AreEqual(oldContracts, newContracts);

            foreach (ContractData contract in newContracts)
            {
                Assert.AreNotEqual(contract.Id, toBeRemoved.Id);
            }

            //app.Auth.LogOut();
        }
    }
}
