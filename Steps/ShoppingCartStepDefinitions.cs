using AutomationFramework.POM.Swaglabs;
using AutomationFramework.Webdriver;
using Reqnroll;

namespace AutomationFramework.Steps
{
    [Binding]
    public class ShoppingCartStepDefinitions
    {
        ShoppingCartPage shoppingCartPage;

        public ShoppingCartStepDefinitions(WebdriverManager webdriverManager)
        {
            var driver = webdriverManager.GetDriver();
            shoppingCartPage = new ShoppingCartPage(driver);
        }

        [Then("the {string} product has amount {int} in the shopping cart")]
        public void TheProductHasAmountInShoppingCart(string productName, int expectedAmountOfItems)
        {
            shoppingCartPage.CheckProductIsAtCart(productName, expectedAmountOfItems);
        }

        [Then("the user clicks in the Checkout button")]
        public void TheUserClicksInTheCheckoutButton()
        {
            shoppingCartPage.ClickCheckoutButton();
        }

    }
}
