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
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void OpenMainPage()
        {
            Navigate(baseURL + "addressbook/");
        }
        public void GoToContactPage()
        {
            Navigate(baseURL + "addressbook/");
        }





    }
}
