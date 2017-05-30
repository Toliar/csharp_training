using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTest : ContactTestBase
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

            List<ContactData> oldContacts = ContactData.GetAllFromDB();
            ContactData toBeModified = oldContacts[0];

            app.Contacts.ModifyContact(toBeModified, changedcontact);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAllFromDB();
            oldContacts[0] = changedcontact;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);


        } 

    }
}
