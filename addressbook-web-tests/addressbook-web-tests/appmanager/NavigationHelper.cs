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
