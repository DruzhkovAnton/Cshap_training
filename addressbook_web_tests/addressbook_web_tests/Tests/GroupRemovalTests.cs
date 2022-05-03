using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


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

            if (app.Groups.IsGroupCreate(1))
            {
                GroupData group = new GroupData("удаление");
                group.Header = "";
                group.Footer = "";
                app.Groups.Create(group);
            }
            app.Groups.Remove(1);
            app.Auth.LogOut();
        }

    }
}
