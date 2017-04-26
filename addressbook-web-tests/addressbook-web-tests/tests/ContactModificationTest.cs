using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTest : TestBase
    {
        [Test]
        public void ContactModificationTests()
        {
            ContactData changedcontact= new ContactData();
            changedcontact.Firstname = "4444";
            changedcontact.Lastname = "55555";


            app.Contacts.ModifyContact(changedcontact);


        } 

    }
}
