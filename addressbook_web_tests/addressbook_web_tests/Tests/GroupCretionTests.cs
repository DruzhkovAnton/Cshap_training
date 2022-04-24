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
            GroupData group = new GroupData("aaa");
            group.Header = "sss";
            group.Footer = "ddd";
            app.Groups.Create(group);
            app.Auth.LogOut();
        }

        [Test]
        public void addNewEmptyGroupTests()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Groups.Create(group);
            app.Auth.LogOut();
        }
    }
}
