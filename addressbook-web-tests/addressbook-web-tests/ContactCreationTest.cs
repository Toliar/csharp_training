using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : TestBase
    {
       

        [Test]
        public void  CreatesContact()
        {
            OpenMainPage();
            Login(new AccountData());
            GoToNewContactPage();
            ContactData newcontact = new ContactData();
            newcontact.Firstname = "111";
            newcontact.Lastname = "222";
            FillContactInfo(newcontact);
            LogOut();
        }

        

        
        
    }
}
