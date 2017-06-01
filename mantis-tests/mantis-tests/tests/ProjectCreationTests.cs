using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
  
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
       

        [Test]
        public void ProjectCreationTest()
        {
            ProjectData newProject = new ProjectData { Name = "213213" };

            app.Project.Create(newProject);

        }
    }
}
