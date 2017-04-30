using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected AppManager manager;

        public HelperBase(AppManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
            
        }
        protected IWebElement FindElementByName(string name)
        {
            return this.driver.FindElement(By.Name(name));
        }
        protected IWebElement FindElementById(string index)
        {
            return this.driver.FindElement(By.Id(index));
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

        protected IWebElement FindElementByXPath(int index)
        {
           return this.driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]"));
        }
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }

        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


    }
}