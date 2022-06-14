using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace addressBookWebTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {


            if (app.Groups.IsGroupCreate(0))
            {
                GroupData group = new GroupData("удаление");
                group.Header = "";
                group.Footer = "";
                app.Groups.Create(group);
            }
            List<GroupData> oldGroups =  GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

            //app.Auth.LogOut();
        }

    }
}
