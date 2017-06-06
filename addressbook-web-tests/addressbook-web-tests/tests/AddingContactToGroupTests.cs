using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
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
            ContactData contact = ContactData.GetAllFromDB().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);

        }

    }
}
