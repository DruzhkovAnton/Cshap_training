using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace addressBookWebTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("modifyGroups");
            newData.Header = null;
            newData.Footer = null;


            if (app.Groups.IsGroupCreate(0))
            {
                GroupData group = new GroupData("new groups");
                group.Header = "";
                group.Footer = "";
                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(oldData, newData);
            Assert.AreEqual(oldGroups.Count, GroupData.GetAll().Count);

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }


            //app.Auth.LogOut();
        }
    }
}
