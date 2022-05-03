using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace addressBookWebTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("modifyGroups");
            newData.Header = null;
            newData.Footer = null;


            if (app.Groups.IsGroupCreate(1))
            {
                GroupData group = new GroupData("new groups");
                group.Header = "";
                group.Footer = "";
                app.Groups.Create(group);
            }
            app.Groups.Modify(1, newData);
            app.Auth.LogOut();
        }
    }
}
