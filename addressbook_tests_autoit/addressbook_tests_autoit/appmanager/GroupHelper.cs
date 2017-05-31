using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();

            string count = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.a6ad9a1", "GetItemCount", "#0","");
            for (int i=0;i < int.Parse(count); i++)
            {
               string item = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.a6ad9a1", "GetText", "#0|#"+i, "");
                list.Add(new GroupData() {
                Name= item});
            }
            CloseGroupsDialogue();
            return list;
        }

        internal void Remove(int index)
        {
            OpenGroupsDialogue();
            SelectGroupToDelete(index);
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.a6ad9a1"); // click delete button
            aux.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.a6ad9a3");
            CloseGroupsDialogue();

        }

        private void SelectGroupToDelete(int index)
        {
            aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.a6ad9a1", "Select", "#0|#" + index, "");
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.a6ad9a3");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.a6ad9a4");
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.a6ad9a12");
            aux.WinWait(GROUPWINTITLE);
        }
    }
}