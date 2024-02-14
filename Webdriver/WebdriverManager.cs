using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationFramework.Webdriver
{
    public class WebdriverManager
    {
        private IWebDriver driver;

        public void SetupDriver()
        {
            this.driver = new ChromeDriver(
                ChromeDriverService.CreateDefaultService("C:\\temp\\drivers"),
                new ChromeOptions(),
                TimeSpan.FromSeconds(15));
            this.driver.Manage().Window.Maximize();
        }

        public void DisposeDriver()
        {
            this.driver.Dispose();
            this.driver.Quit();
        }

        public IWebDriver GetDriver() 
        {
            return this.driver;
        }
    }
}
