using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
       

        public GroupHelper(IWebDriver driver) :base(driver) {
           
        }

        public void SubmitGroupCreation()
        {
            FindElementByName("submit").Click();
        }

        public void FillGroupForm(GroupData group)
        {
            FindElementByName("group_name").Clear();
            FindElementByName("group_name").SendKeys(group.Name);
            FindElementByName("group_header").Clear();
            FindElementByName("group_header").SendKeys(group.Header);
            FindElementByName("group_footer").Clear();
            FindElementByName("group_footer").SendKeys(group.Footer);
        }

        public void InitNewGroupCreation()
        {
            FindElementByName("new").Click();
        }
        public void ReturnToGroupPage()
        {
            FindElementByLinkText("group page").Click();
        }

    }
}
