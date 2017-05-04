using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTest : AuthTestBase
    {
        [Test]
        public void ContactModificationTests()
        {
            
            if (!app.Contacts.IsFirstContactExist(1))
            {
                ContactData defaultcontact = new ContactData();
                defaultcontact.Firstname = "first1";
                defaultcontact.Lastname = "last1";

                app.Contacts.CreateContact(defaultcontact);
            }
            ContactData changedcontact= new ContactData();
            changedcontact.Firstname = "4444";
            changedcontact.Lastname = "55555";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.ModifyContact(changedcontact);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0] = changedcontact;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);


        } 

    }
}
