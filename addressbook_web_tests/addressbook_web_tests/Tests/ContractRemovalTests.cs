using NUnit.Framework;

namespace addressBookWebTests
{
    [TestFixture]
    public class ContractRemovalTests : AuthTestBase
    {
        [Test]
        public void ContractRemovalTest()
        {
            app.Contract.Removal(2);
            app.Auth.LogOut();
        }
    }
}
