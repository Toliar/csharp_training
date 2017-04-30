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
            app.Contacts.CreateContact(newcontact);
            // app.Auth.LogOut();
        }

        




    }
}
