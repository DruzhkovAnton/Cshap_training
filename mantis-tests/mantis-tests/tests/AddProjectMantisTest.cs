using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests 
{
    [TestFixture]
    public class AddProjectMantisTest : AuthTestBase
    {

        [Test]
        public void TestAddProjectMantis()
        {

            ProjectData project = new ProjectData("ProjectTest", "DescriptionTest");

            List<ProjectData> oldProjects = app.Project.GetProjectList();

            if (app.Project.IsProjectPresent(project.Name))
            {
                project.Name = project.Name + GenerateRandomNumericString(10);
            }
            app.Project.Create(project);

            List<ProjectData> newProjects = app.Project.GetProjectList();

            Assert.AreEqual(oldProjects.Count + 1, newProjects.Count);

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

        }


    }
}
