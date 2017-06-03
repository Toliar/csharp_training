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
            driver.FindElement(By.CssSelector("input[type=submit]")).Click();
            return this;
        }

        internal bool IsFirstProjecttExist(int index)
        {
            manager.Navigate.OpenManagePage();
            manager.Navigate.OpenProjectManagePage();
            return IsElementPresent(By.CssSelector("div.widget-box:nth-of-type(2) table tbody tr a[href]"));
                
        }

        internal ProjectHelper Remove(int index)
        {
            manager.Navigate.OpenManagePage();
            manager.Navigate.OpenProjectManagePage();
            RemoveProjectAtIndex(index);

            return this;
        }

        private void RemoveProjectAtIndex(int index)
        {
            driver.FindElement(By.CssSelector("div.widget-box:nth-of-type(2) table tbody tr")).FindElement(By.CssSelector("a[href]")).Click();
            driver.FindElement(By.XPath(".//input[@value='Delete Project']")).Click();
            driver.FindElement(By.XPath(".//input[@value='Delete Project']")).Click();
        }

        public List<ProjectData> GetProjectList()
        {
            manager.Navigate.GoToMainPage();
            manager.Navigate.OpenManagePage();
            manager.Navigate.OpenProjectManagePage();

            List<ProjectData> projectsList = new List<ProjectData>();

            ICollection<IWebElement> rows = driver.FindElements(By.CssSelector("div.widget-box:nth-of-type(2) table tbody tr"));
            foreach (IWebElement item in rows)
            {
                var name = item.FindElement(By.CssSelector("a[href]")).Text;
                projectsList.Add(new ProjectData() { Name = name });
            }
            return projectsList;
        }

        public ProjectHelper Create(ProjectData newProject)
        {
            
            manager.Navigate.OpenManagePage();
            manager.Navigate.OpenProjectManagePage();
            CreateNewProject(newProject);

            return this;
        }

    }
}
