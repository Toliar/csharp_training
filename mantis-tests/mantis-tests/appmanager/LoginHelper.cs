﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(AppManager manager) : base(manager)
        {

        }

        public void Login()
        {
            if (!IsUserLoggedAsAdministrator())
            {
                driver.FindElement(By.Id("username")).SendKeys("administrator");
                driver.FindElement(By.XPath("//input[@value='Login']")).Click();
                driver.FindElement(By.Id("password")).SendKeys("root");
                driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            }

        }
        public bool IsUserLoggedAsAdministrator()
        {
            var locator = "//span[@class='user-info']";
            bool isLogged = IsElementPresent(By.XPath(locator));            

            if (isLogged)
                if (driver.FindElement(By.XPath("//span[@class='user-info']")).Text == "administrator")
                    return true;

            return false;
        }
    }
}
