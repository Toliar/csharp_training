using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        private int index=0;
        [Test]
        public void TestGroupRemoval()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            

            app.Groups.Remove(index);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(index);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
