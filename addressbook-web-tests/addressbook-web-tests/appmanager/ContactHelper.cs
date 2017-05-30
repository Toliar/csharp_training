using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;

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

        

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigate.GoToContactPage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void SelectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public string GetContactInformationFromDetailedFormReverse(int index)
        {
            manager.Navigate.GoToContactPage();
            ClickFullInformationButton(index);
            
            IWebElement element = driver.FindElement(By.Id("content"));
            return Regex.Replace(element.Text, "[ \\r\\n]", "");
            
           // return Regex.Replace(s, "(H+:)|(M+:)|(W+:)", "");

        }
        public string GetContactInformationFromTableReverse(int index)
        {
            manager.Navigate.GoToContactPage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));

            string firstName = cells[2].Text;
            string lastName = cells[1].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string fullData = firstName + lastName + address + allPhones;
            return Regex.Replace(fullData, "[ \\r\\n]", "");
        }

        public string GetContactInformationFromEditFormReverse(int index)
        {
            manager.Navigate.GoToContactPage();
            ClickEditButton();
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            if (!string.IsNullOrEmpty(homePhone))  homePhone = "H: " + homePhone;
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            if (!string.IsNullOrEmpty(mobilePhone))  mobilePhone = "M: " + mobilePhone;
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            if (!string.IsNullOrEmpty(workPhone)) workPhone = "W: " + workPhone;

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string fullData = firstName + lastName + address + homePhone + mobilePhone + workPhone+ email+ email2+ email3;
            return Regex.Replace(fullData, "[ \\r\\n]", "");
        }


        public void ClickFullInformationButton(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();
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
        public ContactHelper DeleteContact(ContactData toBeRemoved)
        {
            manager.Navigate.GoToContactPage();
            SelectContact(toBeRemoved.Id);
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

        public ContactHelper ModifyContact(ContactData toBeModified, ContactData newData)
        {
            manager.Navigate.GoToContactPage();
            InitContactModification(toBeModified.Id);
            ModifyContactData(newData);
            FindElementByName("update").Click();
            
            //    manager.Auth.LogOut();
            return this;
        }

        public ContactHelper InitContactModification(string id)
        {
            driver.FindElement(By.XPath(String.Format("//a[@href='edit.php?id={0}']", id))).Click();
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
        public int GetNumberOfSearchResults()
        {
            manager.Navigate.OpenMainPage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);


        }

    }
}
