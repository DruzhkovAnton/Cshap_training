using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected LoginHelper loginHelper;
        protected ManagementMenuHelper navigator;
        protected ProjectManagementHelper projectHelper;

        protected IWebDriver driver;
        protected string baseURL;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/mantisbt-2.2.0/";

            loginHelper = new LoginHelper(this);
            navigator = new ManagementMenuHelper(this, baseURL);
            projectHelper = new ProjectManagementHelper(this);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            API = new APIHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;


            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public LoginHelper Auth
        {
            get { return loginHelper; }
        }

        public ManagementMenuHelper Navigator
        {
            get { return navigator; }
        }

        public ProjectManagementHelper Project
        {
            get { return projectHelper; }
        }

        public APIHelper API { get;  set; }
    }
}
