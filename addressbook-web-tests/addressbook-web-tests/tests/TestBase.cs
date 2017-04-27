using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected AppManager app;

        [SetUp]
        public void SetupTest()
        {
            app = AppManager.GetInstance();

        }
    }
}