using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class AdminHelper : HelperBase
    {
        private string baseUrl;

        public AdminHelper(AppManager manager, string baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }

        public List<AccountData> GetAllAccounts()
        {
            IWebDriver driver = OpenAppAndLogin();
            //open user manage page
            // find all user and id
            //fir find all user and id
            return null;
        }
        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            // open user page
            // delete user page
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseUrl + "login_page.php";
            driver.FindElement(By.XPath(""));  // login
            return driver;
        }
    }
}
