using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GroupWinTitle = "Group editor";
        public static string DeleteGroupWinTitle = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        internal bool IsGroupCreate(int v)
        {
            OpenGroupsDialog();
            string existItem =
            aux.ControlTreeView(GroupWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "Exists", "#0|#"+v, "");
            if (existItem == "1")
            {
                return true;
            }
            else return false;
        }

        internal void Add(GroupData newGroup)
        {
            aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GroupWinTitle);
            aux.ControlClick(GroupWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupDialog();
        }

        public void Removal(int v)
        {
            OpenGroupsDialog();
            SelectGroup(v);
            OpenDeleteGroupsDialog();
            SelectAllDeleteInGroupsButton();
            OkButtonClick();
            CloseGroupDialog();
                
        }

        private void OkButtonClick()
        {
            aux.ControlClick(DeleteGroupWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.WinWait(GroupWinTitle);
        }

        private void SelectAllDeleteInGroupsButton()
        {
            aux.ControlClick(DeleteGroupWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d51");
        }

        private void OpenDeleteGroupsDialog()
        {
            aux.ControlClick(GroupWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(DeleteGroupWinTitle);

        }

        private void SelectGroup(int v)
        {
            aux.ControlTreeView(
                GroupWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "Select", "#0|#" + v, "");
        }

        private void CloseGroupDialog()
        {
            aux.ControlClick(GroupWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        internal List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialog();
            string count = aux.ControlTreeView(
                GroupWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                GroupWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupDialog();
            return list;
        }

        private void OpenGroupsDialog()
        {
            aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GroupWinTitle);
        }
    }
}