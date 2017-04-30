using System;
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
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                LogOut();
            }

            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            
            FindElementByCssSelector("input[type=\"submit\"]").Click();
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text 
                == "(" + account.Username + ")";

        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public void LogOut()
        {
            if (IsLoggedIn())
            {
                FindElementByLinkText("Logout").Click();
            }
        }



    }
}
