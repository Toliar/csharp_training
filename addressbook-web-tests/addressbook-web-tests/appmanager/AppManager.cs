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
    public class AppManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigate;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public AppManager()
        {
            driver = new FirefoxDriver(new FirefoxBinary("C:\\Users\\a.rudakov\\Downloads\\firefoxsdk\\bin\\firefox.exe"), new FirefoxProfile());
            baseURL = "http://localhost:8889/";
            loginHelper = new LoginHelper(driver);
            navigate = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);

            
            
            
        }
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }
        public NavigationHelper Navigate
        {
            get
            {
                return navigate;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }

    }

}
