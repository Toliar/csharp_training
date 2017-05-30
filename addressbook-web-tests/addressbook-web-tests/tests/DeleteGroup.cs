using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    class DeleteGroup : GroupTestBase
    {
        [Test]
        public void DeleteGroupTest()
        {
            int index = 0;

            
            if ( ! app.Groups.IsGroupFirstGroupExist(index))
            {
                GroupData defaultData = new GroupData("1111");
                app.Groups.Create(defaultData);
            }

            List<GroupData> oldGroups = GroupData.GetAllFromDB();
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.DeleteGroup(oldGroups[0]);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAllFromDB();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
