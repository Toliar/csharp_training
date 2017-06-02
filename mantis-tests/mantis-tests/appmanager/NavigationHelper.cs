using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;
        public NavigationHelper(AppManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

       public void OpenManagePage()
        {
            driver.FindElement(By.LinkText("Manage")).Click();
        }
        public void OpenProjectManagePage()
        {
            driver.FindElement(By.LinkText("Manage Projects")).Click();
        }
        
        public void GoToMainPage()
        {

            driver.Navigate().GoToUrl(baseURL + "mantisbt-2.4.1/");

        }
        public void OpenMainPage()
        {
            if (driver.Url == baseURL + "addressbook/")
            {
                return;
            }
            Navigate(baseURL + "addressbook/");
        }

    }
}
