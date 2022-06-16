using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void LogIn(AccountData account)
        {
            Type(By.Name("username"), account.Username);
            driver.FindElement(By.XPath("//*[@id='login-form']/fieldset/input[2]")).Click();
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//*[@id='login-form']/fieldset/input[3]")).Click();

        }

        public void LogOut()
        {

        }
    }
}
