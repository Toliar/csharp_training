using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //preparation
            app.Auth.LogOut();

            AccountData account = new AccountData("admin", "secret");
            // Action
            app.Auth.Login(account);
            // Verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));

        }
        [Test]
        public void LoginWithNonValidCredentials()
        {
            //preparation
            app.Auth.LogOut();

            AccountData account = new AccountData("admin", "123456");
            // Action
            app.Auth.Login(account);
            // Verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));

        }

    }
}
