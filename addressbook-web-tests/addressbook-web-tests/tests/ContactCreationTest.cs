using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : TestBase
    {
       

        [Test]
        public void  CreatesContact()
        {
            ContactData newcontact = new ContactData();
            newcontact.Firstname = "111";
            newcontact.Lastname = "222";

            app.Navigate.GoToNewContactPage();
            app.Contacts.FillContactInfo(newcontact);
            app.Auth.LogOut();
        }

        

        
        
    }
}
