using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressBookWebTests
{
    [TestFixture]
    public class GroupCretionTests : TestBase
    {
        [Test]
        public void addNewGroupTests()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "sss";
            group.Footer = "ddd";
            FillGroupForm(group);
            SubmitGroupCreation();
            GoToHomePage();
            LogOut();
        }      
    }
}
