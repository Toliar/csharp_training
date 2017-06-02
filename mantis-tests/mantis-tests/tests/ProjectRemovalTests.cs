using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()

        {
            int index = 0;
            
            List<ProjectData> oldProjects = app.Project.GetProjectList();
            if (!app.Project.IsFirstContactExist(index))
            {
                ProjectData newProject = new ProjectData { Name = GenerateRandomString(10) };
                app.Project.Create(newProject);
            }
                app.Project.Remove(index);

            List<ProjectData> newProjects = app.Project.GetProjectList();

            oldProjects.RemoveAt(index);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }

    }
}
