using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
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
        internal NavigationHelper Navigate { get; set; }
        internal LoginHelper Login { get; set; }
        

        public ProjectHelper Project { get; set; }


        //   protected LoginHelper loginHelper;


        private static ThreadLocal<AppManager> app = new ThreadLocal<AppManager>();
       

        private AppManager()
        {
            driver = new FirefoxDriver(new FirefoxBinary("C:\\Users\\a.rudakov\\Downloads\\firefoxsdk\\bin\\firefox.exe"), new FirefoxProfile());
            baseURL = "http://localhost:8889/";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Navigate = new NavigationHelper(this, baseURL);
            Login = new LoginHelper(this);
            Project = new ProjectHelper(this);


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
         //   if (! app.IsValueCreated )
        //    {
                AppManager newInstance = new AppManager();
                newInstance.driver.Url = "localhost:8889/mantisbt-2.4.1/login_page.php";
                app.Value = newInstance;
                

        //    }
            return app.Value;
        }
       




    }

}
