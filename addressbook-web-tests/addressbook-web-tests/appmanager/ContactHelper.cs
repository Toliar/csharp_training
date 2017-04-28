using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper:HelperBase
    {
        public ContactHelper(AppManager manager) :base(manager) {

        }

        public ContactHelper DeleteContact(int index)
        {
            manager.Navigate.GoToContactPage();
            SelectContact(index).
            ClickDeleteButton();
            driver.SwitchTo().Alert().Accept();
          //  manager.Auth.LogOut();
            return this;
        }

        public ContactHelper ModifyContact(ContactData contactdata)
        {
            manager.Navigate.GoToContactPage();
            ClickEditButton();
            ModifyContactData(contactdata);
            FindElementByName("update").Click();
        //    manager.Auth.LogOut();
            return this;
        }
        public ContactHelper ModifyContactData(ContactData contactdata)
        {
            Type(By.Name("firstname"), contactdata.Firstname);
            Type(By.Name("lastname"), contactdata.Lastname);
                       
            return this;
        }


        public ContactHelper FillContactInfo(ContactData contactdata)
        {
            Type(By.Name("firstname"), contactdata.Firstname);
            Type(By.Name("lastname"), contactdata.Lastname);
            FindElementByName("submit").Click();
            return this;

        }

        public ContactHelper SelectContact(int index)
        {
            
            driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{index}]")).Click();
            //  var allRows = driver.FindElements(By.CssSelector("table#maintable tr[name=entry]"));
            //  foreach (var row in allRows)
            //  {
            //      var lastName = row.FindElement(By.CssSelector("td:nth-of-type(2)")).Text;
            //      if (lastName == text)
            //          row.FindElement(By.CssSelector("td>input")).Click();
            //  }
            //FindElementById(Id).Click();
            return this;
        }
        protected ContactHelper ClickDeleteButton()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        protected ContactHelper ClickEditButton()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

    }
}
