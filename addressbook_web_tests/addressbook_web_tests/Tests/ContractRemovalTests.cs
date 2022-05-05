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
            }

            List<ContractData> oldContracts = app.Contract.GetContractList();

            app.Contract.Removal(0);

            List<ContractData> newContracts = app.Contract.GetContractList();
            oldContracts.RemoveAt(0);
            oldContracts.Sort();
            newContracts.Sort();
            Assert.AreEqual(oldContracts, newContracts);

            app.Auth.LogOut();
        }
    }
}
