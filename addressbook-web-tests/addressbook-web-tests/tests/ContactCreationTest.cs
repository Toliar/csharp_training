using NUnit.Framework;
using System.Collections.Generic;

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

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CreateContact(newcontact);
            // app.Auth.LogOut();

            
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newcontact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        




    }
}
