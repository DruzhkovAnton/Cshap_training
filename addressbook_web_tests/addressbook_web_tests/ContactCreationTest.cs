using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace addressBookWebTests
{
    [TestFixture]
    public class CreateContactTests : TestBase
    {
        [Test]
        public void addNewContractTests()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToContractPage();
            ContractData contract = new ContractData("aaa", "bbbb");
            contract.Lastname = "sss";
            contract.Nickname = "aaaa";
            contract.Title = "qqqq";
            contract.Company = "wwww";
            contract.Address = "dddd";
            contract.PhoneHome = "1112222";
            contract.Email = "qqqqq";
            contract.Homepage = "www.aaaa.ru";
            FillContractForm(contract);
            SubmitContractCreation();
            GoToHomePage();
            LogOut();
        }
    }
}
