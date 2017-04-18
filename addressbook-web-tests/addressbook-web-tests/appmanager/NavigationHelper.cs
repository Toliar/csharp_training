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
    public class NavigationHelper : HelperBase
    {
      
        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL) : base (driver)
        {
           
            this.baseURL = baseURL;
        }
        public void GoToNewContactPage()
        {
            FindElementByLinkText("add new").Click();
        }
        
        public void GoToGroupPage()
        {
            FindElementByLinkText("groups").Click();
        }
        public void OpenMainPage()
        {
            Navigate(baseURL + "addressbook/");
        }

    }
}
