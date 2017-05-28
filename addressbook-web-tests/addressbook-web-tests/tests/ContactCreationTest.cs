using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Firstname = GenerateRandomString(30),
                    Lastname = GenerateRandomString(30)
                    
                });
            }
            return contacts;
        }


        [Test, TestCaseSource("RandomContactDataProvider")]
        public void  CreatesContact(ContactData newcontact)
        {
           // ContactData newcontact = new ContactData();
           // newcontact.Firstname = "first";
           // newcontact.Lastname = "last";

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
