using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
       
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List <GroupData>();
            for (int i=0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void CreatesGroup(GroupData group)
        {
            
          //  GroupData group = new GroupData("aaa");
          //  group.Header = "dddd";
          // group.Footer = "fff";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            
            Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            
            Assert.AreEqual(oldGroups, newGroups);
          //  app.Auth.LogOut();
        }
/*       [Test]
        public void CreatesEmptyGroup()
        {
            
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            // app.Auth.LogOut();
        } */
           
        [Test]
        public void CreatesBadNameGroup()
        {

            GroupData group = new GroupData("a'A");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            // app.Auth.LogOut();
        }







    }
}
