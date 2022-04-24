using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressBookWebTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            SelectGroups(3);
            RemoveGroup();
            ReturnToGroupsPage();
        }

    }
}
