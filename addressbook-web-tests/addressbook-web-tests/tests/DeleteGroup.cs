using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    class DeleteGroup : AuthTestBase
    {
        [Test]
        public void DeleteGroupTest()
        {
            int index = 0;

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.DeleteGroup(index);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
