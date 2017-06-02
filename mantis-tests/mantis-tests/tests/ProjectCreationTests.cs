using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
  
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
       

        [Test]
        public void ProjectCreationTest()
        {

            ProjectData newProject = new ProjectData { Name = GenerateRandomString(10) };
            List<ProjectData> oldProjects = app.Project.GetProjectList();

            app.Project.Create(newProject);

            List<ProjectData> newProjects = app.Project.GetProjectList();

            oldProjects.Add(newProject);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);


        }
    }
}
