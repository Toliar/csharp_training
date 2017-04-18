
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        private IWebDriver driver;


        public HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }
        protected IWebElement FindElementByName(string name)
        {
            return this.driver.FindElement(By.Name(name));
        }
        protected IWebElement FindElementByLinkText(string text)
        {
            return this.driver.FindElement(By.LinkText(text));
        }
        protected void Navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        protected IWebElement FindElementByCssSelector(string selector)
        {
            return this.driver.FindElement(By.CssSelector(selector));
        }

    }
}