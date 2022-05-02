using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressBookWebTests.Tests
{
    [TestFixture]
    public class ContractCreationTests : TestBase
    {
        [Test]
        public void ContractCreationTest()
        {

            ContractData newData = new ContractData("zzz", "xxx");
            newData.Lastname = "ccc";
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
