using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class DeleteContactFromGroup : AuthTestBase
    {
        [Test]
        public void TestDeleteContactFromGroup()
        {
            GroupData group = GroupData.GetAllFromDB()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAllFromDB().Intersect(oldList).First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
