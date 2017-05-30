using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class ContactTestBase : AuthTestBase
    {   
        [TearDown]
        public void ComapareContacUI_DB()
        {
            if (PERFOM_LONG_UI_CHECKS)
            {
                List<ContactData> contactsUI = app.Contacts.GetContactList();
                List<ContactData> contactsDB = ContactData.GetAllFromDB();
                contactsUI.Sort();
                contactsDB.Sort();
                Assert.AreEqual(contactsUI, contactsDB);
            }
        }
    }
}
