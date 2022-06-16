using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System;
using System.Text;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public static Random rnd = new Random();
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        private List<ProjectData> projectCache = null;

        public List<ProjectData> GetAllProjectSoap(AccountData account)
        {
            
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            List<ProjectData> allProject = new List<ProjectData>();
            Mantis.ProjectData[] projectDatas = client.mc_projects_get_user_accessible
                                                 (account.Username, account.Password);
            foreach (Mantis.ProjectData projectData in projectDatas)
            {
                allProject.Add(new ProjectData(projectData.name, projectData.description));
            }
            return allProject;
        }

        internal void CreateSoap(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectData = new Mantis.ProjectData();
            projectData.name = project.Name;
            projectData.description = project.Description;
            client.mc_project_add(account.Username, account.Password, projectData);
        }

        public List<ProjectData> GetProjectList()
        {
            string cels = "//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr";
            string nameXpath = "./td[1]";
            string descriptionXpath = "./td[5]";

     
         
                projectCache = new List<ProjectData>();
                manager.Navigator.GoToControlProjectTab();

                new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table")).Count > 0);

                ICollection<IWebElement> elements = driver.FindElements(By.XPath(cels));
                foreach (IWebElement element in elements)
                {
                    projectCache.Add(new ProjectData(element.FindElement(By.XPath(nameXpath)).Text,
                                                     element.FindElement(By.XPath(descriptionXpath)).Text));
                }

         
            return new List<ProjectData>(projectCache);
        }

        public void Remove(string name)
        {
            manager.Navigator.GoToControlProjectTab();
            OpenProject(name);
            DeleteProject();
            AplyDeleteProject();

        }

        private void AplyDeleteProject()
        {
            driver.FindElement(By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/form/input[4]")).Click();
        }

        private void DeleteProject()
        {
            driver.FindElement(By.XPath("//*[@id='project-delete-form']/fieldset/input[3]")).Click();
        }

        private void OpenProject(string name)
        {
            driver.FindElement(By.LinkText(name)).Click();
        }

        public void Create(ProjectData project)
        {
            //manager.Navigator.GoToControlMenu();
            //manager.Navigator.GoToControlProjectTab();
            manager.Navigator.GoToNewProject();
            FillProjectForm(project);
            SubmitProjectCreation();

        }


        private void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//*[@id='manage-project-create-form']/div/div[3]/input")).Click();
        }

        private void FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
            Type(By.Name("description"), project.Description);

        }

        public bool IsProjectPresent(string name)
        {
            manager.Navigator.GoToControlProjectTab();
            return IsElementPresent(By.LinkText(name));
        }
    }
}
