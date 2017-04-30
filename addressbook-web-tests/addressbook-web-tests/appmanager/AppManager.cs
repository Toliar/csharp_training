using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

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

        private static ThreadLocal<AppManager> app = new ThreadLocal<AppManager>();

        private AppManager()
        {
            driver = new FirefoxDriver(new FirefoxBinary("C:\\Users\\a.rudakov\\Downloads\\firefoxsdk\\bin\\firefox.exe"), new FirefoxProfile());
            baseURL = "http://localhost:8889/";
            loginHelper = new LoginHelper(this);
            navigate = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }
        ~AppManager()
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

        public static AppManager GetInstance()
        {
            if (! app.IsValueCreated )
            {
                AppManager newInstance = new AppManager();
                newInstance.Navigate.OpenMainPage();
                app.Value = newInstance;
                

            }
            return app.Value;
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
