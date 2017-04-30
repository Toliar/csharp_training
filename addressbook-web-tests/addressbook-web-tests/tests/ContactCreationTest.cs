using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : AuthTestBase
    {
       

        [Test]
        public void  CreatesContact()
        {
            ContactData newcontact = new ContactData();
            newcontact.Firstname = "first";
            newcontact.Lastname = "last";

            app.Navigate.GoToNewContactPage();
            app.Contacts.FillContactInfo(newcontact);
           // app.Auth.LogOut();
        }

        

        
        
    }
}
