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
        public void FillContactInfo(ContactData contactdata)
        {
            FindElementByName("firstname").Clear();
            FindElementByName("firstname").SendKeys(contactdata.Firstname);
            FindElementByName("lastname").Clear();
            FindElementByName("lastname").SendKeys(contactdata.Lastname);
            FindElementByName("submit").Click();
        }
    }
}
