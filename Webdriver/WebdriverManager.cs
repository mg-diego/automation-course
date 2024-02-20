using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace AutomationFramework.Webdriver
{
    public class WebdriverManager
    {
        private IWebDriver driver;

        public void SetupDriver(string driverPath)
        {
            this.driver = new ChromeDriver(
                ChromeDriverService.CreateDefaultService(driverPath),
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

        public void CollectEvidence(string destinationPath, string evidenceName)
        {
            DirectoryInfo di = Directory.CreateDirectory(destinationPath);
            var ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(Path.Combine(destinationPath, $"{evidenceName}.png"));
        }
    }
}
