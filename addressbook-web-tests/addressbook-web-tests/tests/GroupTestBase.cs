using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFOM_LONG_UI_CHECKS )
            {
                List<GroupData> groupsUI = app.Groups.GetGroupList();
                List<GroupData> groupsDB = GroupData.GetAllFromDB();
                groupsUI.Sort();
                groupsDB.Sort();
                Assert.AreEqual(groupsUI, groupsDB);
            }
        }
    }
}
