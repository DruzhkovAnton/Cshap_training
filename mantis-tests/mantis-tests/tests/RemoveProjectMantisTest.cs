using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class RemoveProjectMantisTest : AuthTestBase
    {
        [Test]
        public void TestRemoveProjectMantis()
        {
            ProjectData project = new ProjectData("ProjectTest", "DescriptionTest");

            List<ProjectData> oldProjects = app.Project.GetProjectList();
            if(oldProjects.Count == 0)
            {
                app.Project.Create(project);
            }

            app.Project.Remove(oldProjects[0].Name);



            List<ProjectData> newProjects = app.Project.GetProjectList();

            Assert.AreEqual(oldProjects.Count - 1, newProjects.Count);

            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
