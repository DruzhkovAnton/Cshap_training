using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        private string baseURL;

        public ManagementMenuHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToControlMenu()
        {
            
        }

        public void GoToControlProjectTab()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.2.0/manage_proj_page.php");
        }

        internal void GoToNewProject()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.2.0/manage_proj_create_page.php");
        }

        internal void GoToHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}
