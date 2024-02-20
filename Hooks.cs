using AutomationFramework.Configuration;
using AutomationFramework.POM.Swaglabs;
using AutomationFramework.Webdriver;
using Reqnroll;

namespace AutomationFramework
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on Reqnroll hooks see https://go.reqnroll.net/doc-hooks
        private string configPath = "./testconf.json";
        private Config config;
        int stepNumber;

        [BeforeScenario]
        public void BeforeScenario(WebdriverManager webDriverManager, ConfigurationManager configManager)
        {
            config = configManager.LoadConfiguration(configPath);
            webDriverManager.SetupDriver(config.DriverPath);
            var driver = webDriverManager.GetDriver();
            driver.Navigate().GoToUrl(config.BaseURL);
            stepNumber = 0;
        }

        [AfterScenario]
        public void AfterScenario(WebdriverManager webDriverManager)
        {
            webDriverManager.DisposeDriver();
        }

        [AfterStep]
        public void AfterStep(WebdriverManager webDriverManager, ScenarioContext scenarioContext)
        {
            var evidenceName = $"{stepNumber} {scenarioContext.ScenarioInfo.Title}";
            webDriverManager.CollectEvidence(config.EvidencePath, evidenceName);
            stepNumber++;
        }
    }
}