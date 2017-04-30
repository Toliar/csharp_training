using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
      
        private string baseURL;

        public NavigationHelper(AppManager manager, string baseURL) : base (manager)
        {
           
            this.baseURL = baseURL;
        }
        public void GoToNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        
        public void GoToGroupPage()
        {
            if (driver.Url == baseURL + "addressbook/group.php"
                && IsElementPresent(By.Name("new")))
                {
                return;   
                }

                driver.FindElement(By.LinkText("groups")).Click();
        }
        public void OpenMainPage()
        {
            if (driver.Url == baseURL + "addressbook/")
            {
                return;
            }
            Navigate(baseURL + "addressbook/");
        }
        public void GoToContactPage()
        {
            if (driver.Url == baseURL + "addressbook/")
            {
                return;
            }
            Navigate(baseURL + "addressbook/");
        }





    }
}
