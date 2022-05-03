using NUnit.Framework;

namespace addressBookWebTests
{
    [TestFixture]
    public class ContractModifitationTests : AuthTestBase
    {
        [Test]
        public void ContractModificationTest()
        {

            ContractData newData = new ContractData("ModifyContract", "xxx");
            newData.Lastname = "ccc1";
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
                contract.Lastname = "ccc1";
                contract.Nickname = "vvv";
                contract.Title = "111";
                contract.Company = "222";
                contract.Address = "333";
                contract.PhoneHome = "44444";
                contract.Email = "5555";
                contract.Homepage = "www.jjjj.ru";
            }
            app.Contract.Modify(2, newData);
            app.Auth.LogOut();
        }

    }
}
