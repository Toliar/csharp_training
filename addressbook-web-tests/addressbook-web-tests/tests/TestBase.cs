using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected AppManager app;

         

        [SetUp]
        public void SetupTest()
        {
            app = new AppManager();

            app.Navigate.OpenMainPage();
            app.Auth.Login(new AccountData("admin", "secret"));

        }

        [TearDown]
        public void TeardownTest()
        {

            app.Stop();
        }


        

        



        

      

      

       
    }
}