using NUnit.Framework;
using System.Collections.Generic;

namespace addressBookWebTests
{
    [TestFixture]
    public class ContractCreationTests : AuthTestBase
    {
        [Test]
        public void ContractCreationTest()
        {
            
            ContractData contract = new ContractData("aaa", "bbbb");
            contract.MiddleName = "sss";
            contract.Nickname = "aaaa";
            contract.Title = "qqqq";
            contract.Company = "wwww";
            contract.Address = "dddd";
            contract.PhoneHome = "1112222";
            contract.Email = "qqqqq";
            contract.Homepage = "www.aaaa.ru";

            List<ContractData> oldContracts = app.Contract.GetContractList();

            app.Contract.create(contract);

            Assert.AreEqual(oldContracts.Count + 1, app.Contract.GetContractCount());

            List <ContractData> newContracts = app.Contract.GetContractList();
            oldContracts.Add(contract);
            oldContracts.Sort();
            newContracts.Sort();
            Assert.AreEqual(oldContracts, newContracts);

            app.Auth.LogOut();
        }
    }
}
