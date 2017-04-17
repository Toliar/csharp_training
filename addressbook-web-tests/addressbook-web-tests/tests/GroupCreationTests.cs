using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       

        [Test]
        public void CreatesGroup()
        {
            app.Navigate.OpenMainPage();
            app.Auth.Login(new AccountData("admin","secret"));
            app.Navigate.GoToGroupPage();
            app.Groups.InitNewGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "dddd";
            group.Footer = "fff";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreation();
            app.Groups.ReturnToGroupPage();
            app.Auth.LogOut();
        }



      

       


    }
}
