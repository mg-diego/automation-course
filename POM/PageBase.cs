using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace AutomationFramework.POM
{
    public class PageBase
    {
        protected IWebDriver Driver;
        private readonly TimeSpan DefaultTimeout;

        public PageBase(IWebDriver driver) 
        {
            Driver = driver;
            DefaultTimeout = Driver.Manage().Timeouts().ImplicitWait;
        }

        protected void ClickElement(By elementLocator)
        {
            ClickElement(elementLocator, DefaultTimeout, 0);
        }

        protected void ClickElement(By elementLocator, TimeSpan timeout)
        {
            ClickElement(elementLocator, timeout, 0);
        }

        protected void ClickElement(By elementLocator, int index)
        {
            ClickElement(elementLocator, DefaultTimeout, index);
        }

        protected void ClickElement(By elementLocator, TimeSpan timeout, int index)
        {
            var wait = new WebDriverWait(Driver, timeout);
            wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            Driver.FindElements(elementLocator)[index].Click();
        }

        protected void SendKeysElement(By elementLocator, string value)
        {
            SendKeysElement(elementLocator, value, DefaultTimeout);
        }

        protected void SendKeysElement(By elementLocator, string value, TimeSpan timeout)
        {
            var wait = new WebDriverWait(Driver, timeout);
            wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            Driver.FindElement(elementLocator).SendKeys(value);
        }

        protected void CheckElementText(By elementLocator, string text)
        {
            var element = Driver.FindElement(elementLocator);
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
            Assert.AreEqual(text, element.Text);
        }


        protected IWebElement ElementIsPresent(By elementLocator)
        {
            return ElementIsPresent(elementLocator, DefaultTimeout);
        }
        protected IWebElement ElementIsPresent(By elementLocator, TimeSpan timeout)
        {
            var wait = new WebDriverWait(Driver, timeout);
            return wait.Until(ExpectedConditions.ElementExists(elementLocator));
        }

        protected void ElementIsNotPresent(By elementLocator)
        {
            ElementIsNotPresent(elementLocator, DefaultTimeout);
        }
        protected void ElementIsNotPresent(By elementLocator, TimeSpan timeout)
        {
            var wait = new WebDriverWait(Driver, timeout);
            wait.Until(driver => driver.FindElements(elementLocator).Count == 0);
        }
    }
}
