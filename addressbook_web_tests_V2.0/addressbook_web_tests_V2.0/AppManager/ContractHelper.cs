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
    public class ContractHelper : HelperBase
    {

        public ContractHelper(ApplicationManager manager) : base(manager)
        {
        }

        internal ContractData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhone = cells[5].Text;



            return new ContractData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhone,
                AllEmails = allEmail
            };
        }

        public void RemoveContractToGroup(ContractData contract, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupToRemove(group.Name);
            SelectContract(contract.Id);
            CommitRemoveFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CommitRemoveFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void AddContractToGroup(ContractData contract, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContract(contract.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContractToGroup();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d=>d.FindElements(By.CssSelector("div.msgbox")).Count>0);


        }

        private void SelectGroupToRemove(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        private void CommitAddingContractToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public ContractData GetContactInformationFromDetails(int v)
        {
            manager.Navigator.GoToContractPage();
            InitContractDetails(v);

            driver.FindElements(By.Id("content"));
            string alldetails = driver.FindElement(By.Id("content")).Text;
            //string fio = cells[1].Text;
            //string address = cells[3].Text;
            //string nickname = cells[4].Text;
            //string title = cells[5].Text;
            //string company = cells[6].Text;
            //string address1 = cells[7].Text;
            //string phoneHome = cells[8].Text;
            //string phoneMobile = cells[9].Text;
            //string phoneWork = cells[10].Text;
            //string fax = cells[11].Text;
            //string email = cells[12].Text;
            //string email2 = cells[13].Text;
            //string email3 = cells[14].Text;
            //string homePage = cells[16].Text;
            return new ContractData("", "")
            {
                Alldetails = alldetails

            };

        }



        public ContractData GetContactInformationFromEditForm(int index, int flag)
        {
            manager.Navigator.GoToContractPage();
            InitContractModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value").Trim();
            string midleName = driver.FindElement(By.Name("middlename")).GetAttribute("value").Trim();
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value").Trim();

            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value").Trim();
            string title = driver.FindElement(By.Name("title")).GetAttribute("value").Trim();
            string company = driver.FindElement(By.Name("company")).GetAttribute("value").Trim();

            string address = driver.FindElement(By.Name("address")).Text.Trim();
            string address2 = driver.FindElement(By.Name("address2")).Text.Trim();

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value").Trim();
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value").Trim();
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value").Trim();
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value").Trim();
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value").Trim();

            string email = driver.FindElement(By.Name("email")).GetAttribute("value").Trim();
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value").Trim();
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value").Trim();

            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value").Trim();
            string fio = null;
            string subInfo = null;
            string allPhoneDetails = null;
            string allEmailsDetails = null;

            if (flag == 0)
            {
                if (firstName != null && firstName != "") { firstName = firstName + " "; }
                if (midleName != null && midleName != "") { midleName = midleName + " "; }
                fio = firstName + midleName + lastName;
                if (fio != null && fio != "") { fio = fio + "\r\n"; }

                if (nickName != null && nickName != "") { nickName = nickName + "\r\n"; }
                if (title != null && title != "") { title = title + "\r\n"; }
                if (company != null && company != "") { company = company + "\r\n"; }
                if (address != null && address != "") { address = address + "\r\n"; }
                subInfo = nickName + title + company + address;
                if (subInfo != null && subInfo != "") { subInfo = subInfo + "\r\n"; }

                if (homePhone != null && homePhone != "") { homePhone = "H: " + homePhone + "\r\n"; }
                if (mobilePhone != null && mobilePhone != "") { mobilePhone = "M: " + mobilePhone + "\r\n"; }
                if (workPhone != null && workPhone != "") { workPhone = "W: " + workPhone + "\r\n"; }
                if (fax != null && fax != "") { fax = "F: " + fax + "\r\n"; }
                allPhoneDetails = homePhone + mobilePhone + workPhone + fax;
                if (allPhoneDetails != null && allPhoneDetails != "") { allPhoneDetails = allPhoneDetails + "\r\n"; }

                if (email != null && email != "") { email = email + "\r\n"; }
                if (email2 != null && email2 != "") { email2 = email2 + "\r\n"; }
                if (email3 != null && email3 != "") { email3 = email3 + "\r\n"; }
                if (homePage != null && homePage != "") { homePage = "Homepage:\r\n" + homePage + "\r\n"; }
                allEmailsDetails = email + email2 + email3 + homePage;
                if (allEmailsDetails != null && allEmailsDetails != "") { allEmailsDetails = allEmailsDetails + "\r\n\r\n"; }

                if (address2 != null && address2 != "") { address2 = address2 + "\r\n"; }

            }


            return new ContractData(firstName, lastName)
            {

                MiddleName = midleName,
                Nickname = nickName,
                Title = title,
                Company = company,

                Address = address,
                Address2 = address2,

                PhoneHome = homePhone,
                PhoneMobile = mobilePhone,
                PhoneWork = workPhone,
                PhoneFax = fax,
                Phone2 = phone2,

                Email = email,
                Email2 = email2,
                Email3 = email3,

                Homepage = homePage,

                Fio = fio,
                SubInfo = subInfo,
                AllPhoneDetails = allPhoneDetails,
                AllEmailsDetails = allEmailsDetails







            };

        }

        private List<ContractData> contractCache = null;


        public List<ContractData> GetContractList()
        {
            if (contractCache == null)
            {
                contractCache = new List<ContractData>();
                manager.Navigator.GoToContractPage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    contractCache.Add(new ContractData(element.FindElement(By.XPath("./td[3]")).Text,
                                                       element.FindElement(By.XPath("./td[2]")).Text)
                    {
                        Id = element.FindElement(By.Name("selected[]")).GetAttribute("value")
                    });
                }
            }
            return new List<ContractData>(contractCache);
        }

        public int GetContractCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        internal ContractHelper Remove(ContractData contract)
        {
            manager.Navigator.GoToContractPage();
            SelectContract(contract.Id);
            RemoveContract();
            AlertClick();
            manager.Navigator.GoToContractPage();
            return this;

        }


        internal bool IsContractCreate(int v)
        {
            manager.Navigator.GoToContractPage();
            return !IsElementPresent(By.XPath("//*[@id='maintable']/tbody/tr[" + (v + 2) + "]/td/a/img[@title = 'Edit']"));

        }

        internal ContractHelper Modify(ContractData contract, ContractData newData)
        {
            manager.Navigator.GoToContractPage();
            SelectContract(contract.Id);
            InitContractModificationOnID(contract.Id);
            FillContractForm(newData);
            SubmitContractModification();
            ReturnContractPage();
            return this;

        }



        public ContractHelper Сreate(ContractData contract)
        {
            manager.Navigator.GoToAddNew();
            FillContractForm(contract);
            SubmitContractCreation();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            ReturnContractPage();




            return this;
        }
        public void FillContractForm(ContractData contract)
        {
            Type(By.Name("firstname"), contract.FirstName);
            Type(By.Name("middlename"), contract.MiddleName);
            Type(By.Name("lastname"), contract.Lastname);
            Type(By.Name("nickname"), contract.Nickname);
            Type(By.Name("title"), contract.Title);
            Type(By.Name("company"), contract.Company);
            Type(By.Name("address"), contract.Address);
            Type(By.Name("home"), contract.PhoneHome);
            Type(By.Name("mobile"), contract.PhoneMobile);
            Type(By.Name("work"), contract.PhoneWork);
            Type(By.Name("fax"), contract.PhoneFax);
            Type(By.Name("email"), contract.Email);
            Type(By.Name("email2"), contract.Email2);
            Type(By.Name("email3"), contract.Email3);
            //Type(By.Name("homepage"), contract.PhoneFax);
            //driver.FindElement(By.Name("bday")).Click();
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("22");
            //driver.FindElement(By.Name("bmonth")).Click();
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("March");
            //Type(By.Name("byear"), "1987");
            //driver.FindElement(By.Name("aday")).Click();
            //new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("11");
            //driver.FindElement(By.Name("amonth")).Click();
            //new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("November");
            //Type(By.Name("ayear"), "2022");
            //Type(By.Name("address2"), "123");
            //Type(By.Name("phone2"), "123");
            //Type(By.Name("notes"), "123");
        }



        private ContractHelper ReturnContractPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        private ContractHelper SubmitContractModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contractCache = null;
            return this;
        }

        private ContractHelper InitContractModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContractHelper InitContractModificationOnID(string contactId)
        {
            driver.FindElement(By.CssSelector("[href*='edit.php?id=" + contactId + "']")).Click();
            return this;
        }

        public ContractHelper InitContractDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        private ContractHelper AlertClick()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        private ContractHelper SubmitContractCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contractCache = null;
            return this;
        }

        private ContractHelper RemoveContract()
        {
            driver.FindElement(By.XPath("//*[@id='content']/form[2]/div[2]/input")).Click();
            contractCache = null;
            return this;
        }

        private ContractHelper SelectContract(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/table[@id='maintable']/tbody/tr[" + (index + 2) + "]/td/input")).Click();
            return this;
        }

        private void SelectContract(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }
    }
}
