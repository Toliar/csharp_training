﻿using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper:HelperBase
    {
        public ContactHelper(AppManager manager) :base(manager) {

        }

        public ContactHelper CreateContact(ContactData newcontact)
        {
            manager.Navigate.GoToNewContactPage();
            FillContactInfo(newcontact);
           
            return this;
        }

        public ContactData GetContactCountInformationFromEditForm(int index)
        {
            manager.Navigate.GoToContactPage();
            ClickEditButton();
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
                
            };
        }

        public ContactData GetContactCountInformationFromTable(int index)
        {
            manager.Navigate.GoToContactPage();
            
            IList<IWebElement> cells= driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            
            string firstName = cells[2].Text;
            string lastName = cells[1].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones=allPhones

            };
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

        public int GetContactCount()
        {
            manager.Navigate.GoToContactPage();
            return driver.FindElements(By.CssSelector("[name=entry]")).Count;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();

                List<ContactData> contacts = new List<ContactData>();

                manager.Navigate.GoToContactPage();

                ICollection<IWebElement> rows = driver.FindElements(By.CssSelector("[name=entry]"));
                foreach (IWebElement item in rows)
                {
                    contactCache.Add(new ContactData(item.FindElement(By.XPath(".//td[3]")).Text, item.FindElement(By.XPath(".//td[2]")).Text));
                }

            }
            
            return new List<ContactData> (contactCache);
        }

        public ContactHelper ModifyContact(ContactData contactdata)
        {
            manager.Navigate.GoToContactPage();
            ClickEditButton();
            ModifyContactData(contactdata);
            FindElementByName("update").Click();
            contactCache = null;
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
            contactCache = null;
            return this;

        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{index}]")).Click();
            return this;
            //  var allRows = driver.FindElements(By.CssSelector("table#maintable tr[name=entry]"));
            //  foreach (var row in allRows)
            //  {
            //      var lastName = row.FindElement(By.CssSelector("td:nth-of-type(2)")).Text;
            //      if (lastName == text)
            //          row.FindElement(By.CssSelector("td>input")).Click();
            //  }
            //FindElementById(Id).Click();
        }
        protected ContactHelper ClickDeleteButton()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }
        protected ContactHelper ClickEditButton()
        {
           
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            // driver.FindElements(By.Name("entry"))[index].Find.Elements(By.TagName("td"))[7].FindElement(By.TagName("a")).Click;
            return this;
        }

        public bool IsFirstContactExist(int index)
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]"));
        }


    }
}
