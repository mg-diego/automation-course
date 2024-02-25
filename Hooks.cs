using AutomationFramework.Configuration;
using AutomationFramework.POM.Swaglabs;
using AutomationFramework.Webdriver;
using Reqnroll;
using System.Globalization;
using System.Security.Policy;

namespace AutomationFramework
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on Reqnroll hooks see https://go.reqnroll.net/doc-hooks
        private static string configPath = "./testconf.json";
        private static Config config;
        private static string evidenceFolder;
        private int stepNumber;
        [BeforeTestRun] public static void BeforeTestRun(ConfigurationManager configManager)
        {
            config = configManager.LoadConfiguration(configPath);
            evidenceFolder = Path.Combine(config.EvidencePath, $"{DateTime.UtcNow.ToString("yyy-MM-dd HH-mm-ss", CultureInfo.InvariantCulture)}");
        }

        [BeforeScenario]
        public void BeforeScenario(WebdriverManager webDriverManager, ConfigurationManager configManager)
        {
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
        public void AfterStep(WebdriverManager webDriverManager, ScenarioContext scenarioContext, FeatureContext feature)
        {
            var evidenceName = $"{stepNumber}";
            var featureName = feature.FeatureInfo.Title;
            var scenarioName = scenarioContext.ScenarioInfo.Title;
            var evidencePath = Path.Combine(evidenceFolder, featureName, scenarioName);
            webDriverManager.CollectEvidence(evidencePath, evidenceName);
            stepNumber++;
        }
    }
}