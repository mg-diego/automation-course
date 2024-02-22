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
        private string scenarioEvidencesFolder;

        [BeforeScenario]
        public void BeforeScenario(WebdriverManager webDriverManager, ConfigurationManager configManager, ScenarioContext scenarioContext)
        {           
            config = configManager.LoadConfiguration(configPath);
            scenarioEvidencesFolder = Path.Combine(config.EvidencePath, DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + " " + scenarioContext.ScenarioInfo.Title);
            DirectoryInfo di = Directory.CreateDirectory(scenarioEvidencesFolder);
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
            var evidenceName = $"{stepNumber} - {scenarioContext.StepContext.StepInfo.StepDefinitionType} {scenarioContext.StepContext.StepInfo.Text}";
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                evidenceName = evidenceName.Replace(c.ToString(), string.Empty);
            }
            webDriverManager.CollectEvidence(scenarioEvidencesFolder, evidenceName);
            stepNumber++;
        }
    }
}