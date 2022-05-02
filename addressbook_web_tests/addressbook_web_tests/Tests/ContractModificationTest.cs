using NUnit.Framework;

namespace addressBookWebTests
{
    [TestFixture]
    public class ContractModifitationTests : AuthTestBase
    {
        [Test]
        public void ContractModificationTest()
        {

            ContractData newData = new ContractData("zzz", "xxx");
            newData.Lastname = "ccc1";
            newData.Nickname = "vvv";
            newData.Title = "111";
            newData.Company = "222";
            newData.Address = "333";
            newData.PhoneHome = "44444";
            newData.Email = "5555";
            newData.Homepage = "www.jjjj.ru";

            app.Contract.Modify(2, newData);
            app.Auth.LogOut();
        }

    }
}
