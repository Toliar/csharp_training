using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(AppManager manager) : base(manager) { }

        public ProjectHelper CreateNewProject(ProjectData project)
        {
            driver.FindElement(By.XPath("//input[@value='Create New Project']")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[7]/a/span")).Click();
            return this;
        }
        public ProjectHelper Create(ProjectData newProject)
        {
            manager.Navigate.GoToMainPage();
            manager.Login.Login();
            manager.Navigate.OpenProjectManagePage();
            CreateNewProject(newProject);

            return this;
        }

    }
}
