using NUnit.Framework;

namespace addressBookWebTests
{
    [TestFixture]
    public class ContractRemovalTests : AuthTestBase
    {
        [Test]
        public void ContractRemovalTest()
        {
            if (app.Contract.IsContractCreate(2))
            {
                ContractData contract = new ContractData("NewContract", "xxx");
                contract.Lastname = "ccc1";
                contract.Nickname = "vvv";
                contract.Title = "111";
                contract.Company = "222";
                contract.Address = "333";
                contract.PhoneHome = "44444";
                contract.Email = "5555";
                contract.Homepage = "www.jjjj.ru";
            }
            app.Contract.Removal(2);
            app.Auth.LogOut();
        }
    }
}
