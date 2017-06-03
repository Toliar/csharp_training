using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Collections.Generic;

namespace mantis_tests
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

        public RegistrationHelper Registration { get;  set; }
        internal FtpHelper Ftp { get;  set; }
        public JamesHelper James { get; set; }
        


        public ProjectHelper Project { get; set; }
        public LoginHelper Login { get;  set; }
        public NavigationHelper Navigate { get;  set; }
        public MailHelper Mail { get; set; }
        public AdminHelper Admin { get;  set; }
        public APIHelper API { get; set; }

        //   protected LoginHelper loginHelper;


        private static ThreadLocal<AppManager> app = new ThreadLocal<AppManager>();
        

        private AppManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver = new FirefoxDriver(new FirefoxBinary(@"c:\Program Files (x86)\Mozilla Firefox\firefox.exe"), new FirefoxProfile());
            baseURL = "http://localhost:8889/";
            //Registration = new RegistrationHelper(this);
            //Ftp = new FtpHelper(this);
            //James = new JamesHelper(this);
            Login = new LoginHelper(this);
            Navigate = new NavigationHelper(this, baseURL);
            Project = new ProjectHelper(this);
            Admin = new AdminHelper(this, baseURL);
            API = new APIHelper(this);
            //Mail = new MailHelper(this);


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
                newInstance.driver.Navigate().GoToUrl("http://localhost:8889/mantisbt-2.4.1/login_page.php");
                app.Value = newInstance;

                /*   AppManager newInstance = new AppManager();
                   newInstance.Navigate.OpenMainPage();
                   app.Value = newInstance; */

            }
            return app.Value;
        }
      
       

        

    }

}
