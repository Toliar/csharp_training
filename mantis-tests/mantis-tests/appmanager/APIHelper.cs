using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        private string baseUrl;

        public APIHelper(AppManager manager ) : base(manager)
        {
            
        }

        public void CreateNewIssue(AccountData account,ProjectData project, IssueData issueData )
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;

            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetAllProjectsByApi(AccountData userData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            List<ProjectData> existingProjects = new List<ProjectData>();
            Mantis.ProjectData[] exProjects = client.mc_projects_get_user_accessible(userData.Name, userData.Password);
            
            
            foreach (Mantis.ProjectData project in exProjects)
            {
                ProjectData tempData = new ProjectData();
                
                tempData.Id = project.id;
                tempData.Name = project.name;
                existingProjects.Add(tempData);
               // System.Console.Out.WriteLine(existingProjects.ToString());
            }
            return existingProjects;
        }
        public void CreateProjectByAPI(ProjectData project,AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData
            client.mc_project_add(account.Name,account.Password,)
        }

        public List<AccountData> GetAllAccounts()
        {
            IWebDriver driver = OpenAppAndLogin();
            //open user manage page
            // find all user and id
            //fir find all user and id
            return null;
        }
        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            // open user page
            // delete user page
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseUrl + "login_page.php";
            driver.FindElement(By.XPath(""));  // login
            return driver;
        }
    }
}
