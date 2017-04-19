using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       

        [Test]
        public void CreatesGroup()
        {
            
            GroupData group = new GroupData("aaa");
            group.Header = "dddd";
            group.Footer = "fff";

            
            app.Groups.Create(group);
            app.Auth.LogOut();
        }
        [Test]
        public void CreatesEmptyGroup()
        {
            
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            
            app.Groups.Create(group);
            app.Auth.LogOut();
        }







    }
}
