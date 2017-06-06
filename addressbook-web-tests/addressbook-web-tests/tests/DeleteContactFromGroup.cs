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

            if (!ContactData.GetAllFromDB().Any())
            {
                ContactData defaultcontact = new ContactData();
                defaultcontact.Firstname = "first1";
                defaultcontact.Lastname = "last1";

                app.Contacts.CreateContact(defaultcontact);
            }

            if (!GroupData.GetAllFromDB().Any())
            {
                GroupData defaultData = new GroupData("1111");
                app.Groups.Create(defaultData);
            }

            GroupData group = GroupData.GetAllFromDB()[0];
            List<ContactData> oldList = group.GetContacts();

            if (!ContactData.GetAllFromDB().Intersect(oldList).Any())
            {
                GroupData group1 = GroupData.GetAllFromDB()[0];
                ContactData contact1 = ContactData.GetAllFromDB().Except(oldList).First();

                app.Contacts.AddContactToGroup(contact1, group1);
                oldList = group.GetContacts();
            }

            
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
