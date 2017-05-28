using NUnit.Framework;

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
            int index = 0;

            string fromEditFormReverse = app.Contacts.GetContactInformationFromEditFormReverse(index);
            string fromDetailedInfoReverse = app.Contacts.GetContactInformationFromDetailedFormReverse(index);

            //verification
            Assert.AreEqual(fromEditFormReverse, fromDetailedInfoReverse);
           
        }
    }
}
