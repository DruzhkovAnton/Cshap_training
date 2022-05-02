using NUnit.Framework;


namespace addressBookWebTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Remove(1);
            app.Auth.LogOut();
        }

    }
}
