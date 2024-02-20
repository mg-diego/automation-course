using AutomationFramework.POM.Swaglabs;
using AutomationFramework.Webdriver;

namespace AutomationFramework.Tests
{
    [TestClass]
    public class SwaglabsTests
    {
        private WebdriverManager webDriverManager;
        private string SwagLabsUrl = "https://www.saucedemo.com";
        private LoginPage loginPage;
        private ProductsPage productsPage;
        private HeaderPage headerPage;
        private ShoppingCartPage shoppingCartPage;
        private CheckoutInformationPage checkoutInformationPage;
        private CheckoutOverviewPage checkoutOverviewPage;
        private OrderFinishedPage orderFinishedPage;

        [TestInitialize]
        public void Setup()
        {
            webDriverManager = new WebdriverManager();
            webDriverManager.SetupDriver("C:\\temp\\drivers");
            var driver = webDriverManager.GetDriver();
            driver.Navigate().GoToUrl(SwagLabsUrl);

            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);
            headerPage = new HeaderPage(driver);
            shoppingCartPage = new ShoppingCartPage(driver);
            checkoutInformationPage = new CheckoutInformationPage(driver);
            checkoutOverviewPage = new CheckoutOverviewPage(driver);
            orderFinishedPage = new OrderFinishedPage(driver);
        }

        [TestCleanup]
        public void TearDown()
        {
            webDriverManager.DisposeDriver();
        }

        [TestMethod]
        public void ValidLogin()
        {
            this.loginPage.SetUserName("standard_user");
            this.loginPage.SetPassword("secret_sauce");
            this.loginPage.ClickSubmitButton();

            this.loginPage.CheckUserIsNotAtLoginPage();
        }

        [TestMethod]
        public void InvalidLogin()
        {
            this.loginPage.SetUserName("diego");
            this.loginPage.SetPassword("diego");

            this.loginPage.ClickSubmitButton();

            this.loginPage.CheckUserIsAtLoginPage();
            this.loginPage.CheckErrorMessageText("Epic sadface: Username and password do not match any user in this service");
        }

        [TestMethod]
        public void SlowLogin()
        { 
            this.loginPage.SetUserName("performance_glitch_user");
            this.loginPage.SetPassword("secret_sauce");

            this.loginPage.ClickSubmitButton();

            this.productsPage.CheckUserIsAtProductsPage();
        }

        [TestMethod]
        public void CheckAmountOfProducts()
        {
            this.loginPage.SetUserName("standard_user");
            this.loginPage.SetPassword("secret_sauce");

            this.loginPage.ClickSubmitButton();

            this.productsPage.CheckUserIsAtProductsPage();
            this.headerPage.OpenShoppingCart();
        }

        [TestMethod]
        public void BuyAProduct()
        {
            this.loginPage.SetUserName("standard_user");
            this.loginPage.SetPassword("secret_sauce");

            this.loginPage.ClickSubmitButton();

            this.productsPage.CheckUserIsAtProductsPage();
            this.productsPage.AddProductToCartByName("Sauce Labs Fleece Jacket");

            this.headerPage.OpenShoppingCart();
            this.shoppingCartPage.CheckProductIsAtCart("Sauce Labs Fleece Jacket", 1);
            this.shoppingCartPage.ClickCheckoutButton();

            this.checkoutInformationPage.SetName("Diego");
            this.checkoutInformationPage.SetSurname("Diego");
            this.checkoutInformationPage.SetZipCode("123");
            this.checkoutInformationPage.ClickContinueButton();

            this.checkoutOverviewPage.CheckProductIsAtCart("Sauce Labs Fleece Jacket", 1);
            this.checkoutOverviewPage.ClickFinishButton();

            this.orderFinishedPage.CheckOrderFinishedAppears();
        }
    }
}