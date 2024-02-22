using AutomationFramework.POM.Swaglabs;
using AutomationFramework.Webdriver;
using Reqnroll;

namespace AutomationFramework.Steps
{
    [Binding]
    public class CheckoutOverviewStepDefinitions
    {
        CheckoutOverviewPage checkoutOverviewPage;

        public CheckoutOverviewStepDefinitions(WebdriverManager webdriverManager)
        {
            var driver = webdriverManager.GetDriver();
            checkoutOverviewPage = new CheckoutOverviewPage(driver);
        }

        [Then("the {string} product has amount {int} in the checkout overview")]
        public void TheProductHasAmountInCheckoutOverview(string productName, int expectedAmountOfItems)
        {
            checkoutOverviewPage.CheckProductIsAtCart(productName, expectedAmountOfItems);
        }

        [When("the user clicks in the Finish button")]
        public void TheUserClicksFinishButton()
        {
            checkoutOverviewPage.ClickFinishButton();
        }
    }
}
