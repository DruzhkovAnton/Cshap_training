using NUnit.Framework;


namespace addressBookWebTests
{
    [TestFixture]
    public class ContractCreationTests : AuthTestBase
    {
        [Test]
        public void ContractCreationTest()
        {
            
            ContractData contract = new ContractData("aaa", "bbbb");
            contract.Lastname = "sss";
            contract.Nickname = "aaaa";
            contract.Title = "qqqq";
            contract.Company = "wwww";
            contract.Address = "dddd";
            contract.PhoneHome = "1112222";
            contract.Email = "qqqqq";
            contract.Homepage = "www.aaaa.ru";
            app.Contract.create(contract);
            app.Auth.LogOut();
        }
    }
}
