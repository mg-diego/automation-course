using AutomationFramework.POM.Swaglabs;
using AutomationFramework.Webdriver;
using Reqnroll;

namespace AutomationFramework.Steps
{
    [Binding]
    public class OrderFinishedStepDefinitions
    {
        OrderFinishedPage orderFinishedPage;

        public OrderFinishedStepDefinitions(WebdriverManager webdriverManager)
        {
            var driver = webdriverManager.GetDriver();
            orderFinishedPage = new OrderFinishedPage(driver);
        }

        [Then("the order finished message appears")]
        public void TheOrderFinishedMessageAppears()
        {
            orderFinishedPage.CheckOrderFinishedAppears();
        }
    }
}
