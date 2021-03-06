using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace addressBookWebTests
{
    public class GroupHelper : HelperBase
    {
        private List<GroupData> groupCache = null;
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupData>(groupCache);
        }



        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroups(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroupToId(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(GroupData oldData, GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroupToId(oldData.Id);
            InitGroupModification();
            FillGroupForm(group);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public bool IsGroupCreate(int index)
        {
            manager.Navigator.GoToGroupsPage();
            return !IsElementPresent(By.XPath("//div[@id='content']/form/span[" + (index + 1) + "]/input"));
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        internal double GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroups(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index + 1) + "]/input")).Click();
            return this;
        }

        public GroupHelper SelectGroupToId(string id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='"+id+"']")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {

            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }



        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper GroupExist() 
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsGroupCreate(0))
            {
                GroupData group = new GroupData("zzz");
                group.Header = "ttt";
                group.Footer = "kkk";
                Create(group);
            }
            return this;
        }
    }
}
