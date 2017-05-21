using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable= app.Contacts.GetContactCountInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactCountInformationFromEditForm(0);
            
            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestDetailedContactInformationReverse()
        {
            int index = 3;

            string fromTableReverse = app.Contacts.GetContactInformationFromTableReverse(index);
            string fromDetailedInfoReverse = app.Contacts.GetContactInformationFromDetailedFormReverse(index);

            //verification
            Assert.AreEqual(fromTableReverse, fromDetailedInfoReverse);
           
        }
    }
}
