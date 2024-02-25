using System;
using AutomationFramework.POM.Swaglabs;
using AutomationFramework.Webdriver;
using Reqnroll;

namespace AutomationFramework.Steps
{
    [Binding]
    public class PurchaseStepDefinitions
    {

        private HeaderPage headerPage;
        private ShoppingCartPage shoppingCartPage;
        private CheckoutInformationPage checkoutInformationPage;
        private CheckoutOverviewPage checkoutOverviewPage;
        private OrderFinishedPage orderFinishedPage;
        PurchaseStepDefinitions(WebdriverManager webDriverManager)
        {
            var driver = webDriverManager.GetDriver();
            headerPage = new HeaderPage(driver);
            shoppingCartPage = new ShoppingCartPage(driver);
            checkoutInformationPage = new CheckoutInformationPage(driver);
            checkoutOverviewPage = new CheckoutOverviewPage(driver);
            orderFinishedPage = new OrderFinishedPage(driver);
    }

        [When("the user confirms the {string}  has {int} items")]
        public void WhenTheUserConfirmsTheHasItems(string item, int quantity)
        {
            this.headerPage.OpenShoppingCart();
            this.shoppingCartPage.CheckProductIsAtCart(item, quantity);
            this.shoppingCartPage.ClickCheckoutButton();
        }

        [When("the user continues his purchase with first name {string}, last name {string} and postal code {string}")]
        public void WhenTheUserContinuesHisPurchaseWithFirstNameLastNameAndPostalCode(string user, string surname, string postalCode)
        {
            this.checkoutInformationPage.SetName(user);
            this.checkoutInformationPage.SetSurname(surname);
            this.checkoutInformationPage.SetZipCode(postalCode);
            this.checkoutInformationPage.ClickContinueButton();
        }

        [When("the user reviews the {string}  has {int} items")]
        public void WhenTheUserReviewsTheHasItems(string item, int quantity)
        {

            this.checkoutOverviewPage.CheckProductIsAtCart(item, quantity);
            this.checkoutOverviewPage.ClickFinishButton();
        }

        [Then("the system confirms the successful purchase")]
        public void ThenTheSystemConfirmsTheSuccessfulPurchase()
        {
            this.orderFinishedPage.CheckOrderFinishedAppears();
        }
    }
}
