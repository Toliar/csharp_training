using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
       

        public GroupHelper(AppManager manager) :base(manager) {
           
        }

        public GroupHelper Create(GroupData group) {
            manager.Navigate.GoToGroupPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }
        

        public GroupHelper SubmitGroupCreation()
        {
            FindElementByName("submit").Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            FindElementByName("group_name").Clear();
            FindElementByName("group_name").SendKeys(group.Name);
            FindElementByName("group_header").Clear();
            FindElementByName("group_header").SendKeys(group.Header);
            FindElementByName("group_footer").Clear();
            FindElementByName("group_footer").SendKeys(group.Footer);
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            FindElementByName("new").Click();
            return this;
        }
        public GroupHelper ReturnToGroupPage()
        {
            FindElementByLinkText("group page").Click();
            return this;
        }

    }
}
