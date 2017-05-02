using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ModificateGroup : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;
            int index = 0;

            // Check if first group exist
            if(app.Groups.IsGroupFirstGroupExist(index))
            {
                GroupData defaultData = new GroupData("1111");
                app.Groups.Create(defaultData);
            }
            app.Groups.Modify(0, newData);
        }

    }
}
