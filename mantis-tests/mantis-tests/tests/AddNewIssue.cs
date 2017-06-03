using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{

    [TestFixture]
    public class AddNewIssueTests : TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            ProjectData project = new ProjectData() { Id = "1" };
            AccountData account = new AccountData() { Name = "administrator", Password = "root" };
            IssueData issueData = new IssueData()
            {
                Summary = "Test summary",
                Description = "Test description",
                Category = "General"
            };


            app.API.CreateNewIssue(account,project, issueData);
            app.API.GetAllProjectsByApi(account);
        }
    }
}
