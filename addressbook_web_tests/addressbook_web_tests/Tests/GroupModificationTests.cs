using NUnit.Framework;

namespace addressBookWebTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("cc123c");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(1, newData);
            app.Auth.LogOut();
        }
    }
}
