using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : TestBase
    {
       

        [Test]
        public void  CreatesContact()
        {
            app.Navigate.OpenMainPage();
            app.Auth.Login(new AccountData());
            app.Navigate.GoToNewContactPage();
            ContactData newcontact = new ContactData();
            newcontact.Firstname = "111";
            newcontact.Lastname = "222";
            app.Contacts.FillContactInfo(newcontact);
            app.Auth.LogOut();
        }

        

        
        
    }
}
