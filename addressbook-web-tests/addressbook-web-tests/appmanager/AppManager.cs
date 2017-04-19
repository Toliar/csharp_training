using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class AppManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        public IWebDriver Driver {
            get
            {
                return driver;
            }
        }

        protected LoginHelper loginHelper;
        protected NavigationHelper navigate;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public AppManager()
        {
            driver = new FirefoxDriver(new FirefoxBinary("C:\\Users\\a.rudakov\\Downloads\\firefoxsdk\\bin\\firefox.exe"), new FirefoxProfile());
            baseURL = "http://localhost:8889/";
            loginHelper = new LoginHelper(this);
            navigate = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);

            
            
            
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
