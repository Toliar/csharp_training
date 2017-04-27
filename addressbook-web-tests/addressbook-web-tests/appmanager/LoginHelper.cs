using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        

        public LoginHelper( AppManager manager) : base(manager)
        {
           
        }
        public void Login(AccountData account)
        {
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            
            FindElementByCssSelector("input[type=\"submit\"]").Click();
        }
        public void LogOut()
        {
            FindElementByLinkText("Logout").Click();
        }



    }
}
