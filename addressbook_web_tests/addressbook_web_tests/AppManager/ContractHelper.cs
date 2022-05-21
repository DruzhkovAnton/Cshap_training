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

        public ContractData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToContractPage();
            InitContractModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string addres = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContractData(firstName, lastName)
            {
                Address = addres,

                PhoneHome = homePhone,
                PhoneMobile = mobilePhone,
                PhoneWork = workPhone,
                Phone2 = phone2,

                Email = email,
                Email2 = email2,
                Email3 = email3
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

        internal ContractHelper Remove(int v)
        {
            manager.Navigator.GoToContractPage();
            SelectContract(v);
            RemoveContract();
            AlertClick();
            manager.Navigator.GoToContractPage();
            return this;

        }

 
        internal bool IsContractCreate(int v)
        {
            manager.Navigator.GoToContractPage();
            return !IsElementPresent(By.XPath("//*[@id='maintable']/tbody/tr[" + (v+2) + "]/td/a/img[@title = 'Edit']"));

        }

        internal ContractHelper Modify(int v, ContractData newData)
        {
            manager.Navigator.GoToContractPage();
            SelectContract(v);
            InitContractModification(v);
            FillContractForm(newData);
            SubmitContractModification();
            ReturnContractPage();
            return this;

        }



        public ContractHelper create(ContractData contract)
        {
            manager.Navigator.GoToAddNew();
            FillContractForm(contract);
            SubmitContractCreation();
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
            Type(By.Name("phone2"), "123");
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
            driver.FindElement(By.XPath("//div[@id='content']/form/table[@id='maintable']/tbody/tr["+(index+2)+"]/td/input")).Click();
            return this;
        }
    }
}
