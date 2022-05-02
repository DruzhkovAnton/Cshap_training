using NUnit.Framework;


namespace addressBookWebTests
{
    [TestFixture]
    public class GroupCretionTests : AuthTestBase
    {
        [Test]
        public void addNewGroupTests()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "sss";
            group.Footer = "ddd";
            app.Groups.Create(group);
            //app.Auth.LogOut();
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
