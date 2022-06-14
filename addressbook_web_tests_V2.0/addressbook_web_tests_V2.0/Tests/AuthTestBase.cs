using NUnit.Framework;

namespace addressBookWebTests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new AccountData("admin", "secret"));

        }
    }
}
