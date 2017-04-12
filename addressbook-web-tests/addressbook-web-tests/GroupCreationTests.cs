using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       

        [Test]
        public void CreatesGroup()
        {
            OpenMainPage();
            Login(new AccountData("admin","secret"));
            GoToGroupPage();
            InitNewGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "dddd";
            group.Footer = "fff";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            LogOut();
        }



      

       


    }
}
