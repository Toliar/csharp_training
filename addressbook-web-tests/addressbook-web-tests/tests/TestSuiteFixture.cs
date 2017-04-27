using NUnit.Framework;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        

        [SetUp]
        public void InitApplicationManager()
        {
            AppManager app = AppManager.GetInstance();

            app.Navigate.OpenMainPage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

    }
}
