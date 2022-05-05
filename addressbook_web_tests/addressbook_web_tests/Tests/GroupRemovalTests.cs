using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace addressBookWebTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            //app.Navigator.GoToGroupsPage();
            //if (!app.Navigator.IsElementPresent(By.ClassName("group")))
            //{

            //}

            if (app.Groups.IsGroupCreate(0))
            {
                GroupData group = new GroupData("удаление");
                group.Header = "";
                group.Footer = "";
                app.Groups.Create(group);
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            app.Auth.LogOut();
        }

    }
}
