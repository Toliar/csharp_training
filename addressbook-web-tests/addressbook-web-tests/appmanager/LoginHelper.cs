using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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
