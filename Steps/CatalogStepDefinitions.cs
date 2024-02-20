using System;
using AutomationFramework.POM.Swaglabs;
using AutomationFramework.Webdriver;
using Reqnroll;

namespace AutomationFramework.Steps
{
    [Binding]
    public class CatalogStepDefinitions
    {
        ProductsPage productsPage;
        HeaderPage headerPage;

        public CatalogStepDefinitions(WebdriverManager webdriverManager)
        {
            var driver = webdriverManager.GetDriver();
            productsPage = new ProductsPage(driver);
            headerPage = new HeaderPage(driver);
        }
        [When("the user adds {string} to the cart")]
        public void WhenTheUserAddToTheCart(string productName)
        {
            productsPage.AddProductToCartByName(productName);
        }

        [Then("The number of cart items is {int}")]
        public void ThenTheNumberOfCartItemsIs(int NumberOfItems)
        {
            headerPage.CheckNumberOfItemsInCart(NumberOfItems);
        }

        [When("the user adds multiple products to the cart")]
        public void WhenTheUserAddsMultipleProductsToTheCart(DataTable dataTable)
        {
            var product = dataTable.Header.First();
            foreach (var row in dataTable.Rows)
            {
                productsPage.AddProductToCartByName(row[product]);
            }
        }

    }
}
