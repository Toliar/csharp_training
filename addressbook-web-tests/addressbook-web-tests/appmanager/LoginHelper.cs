using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        

        public LoginHelper(IWebDriver driver) : base(driver)
        {
           
        }
        public void Login(AccountData account)
        {
            FindElementByName("user").Clear();
            FindElementByName("user").SendKeys(account.Username);
            FindElementByName("pass").Clear();
            FindElementByName("pass").SendKeys(account.Password);
            FindElementByCssSelector("input[type=\"submit\"]").Click();
        }
        public void LogOut()
        {
            FindElementByLinkText("Logout").Click();
        }



    }
}
