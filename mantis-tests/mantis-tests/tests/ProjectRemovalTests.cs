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
            
            List<ProjectData> oldProjects = app.API.GetAllProjectsByApi(new AccountData()); 
            if (!app.Project.IsFirstProjecttExist(index))
            {
                ProjectData newProject = new ProjectData { Name = GenerateRandomString(10) };
                app.API.CreateProjectByAPI(newProject, new AccountData());
            }
                app.Project.Remove(index);

            List<ProjectData> newProjects = app.API.GetAllProjectsByApi(new AccountData()); ;

            oldProjects.RemoveAt(index);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }

    }
}
