using AutomationFramework.POM.Swaglabs;
using AutomationFramework.Webdriver;

namespace AutomationFramework.Tests
{
    [TestClass]
    public class SwaglabsTests
    {
        private WebdriverManager webDriverManager;
        private string SwagLabsUrl = "https://www.saucedemo.com/v1/";
        private LoginPage loginPage;
        private ProductsPage productsPage;

        [TestInitialize]
        public void Setup()
        {
            webDriverManager = new WebdriverManager();
            webDriverManager.SetupDriver();
            var driver = webDriverManager.GetDriver();
            driver.Navigate().GoToUrl(SwagLabsUrl);

            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);
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
            this.productsPage.CheckAmountOfProducts(6);
        }
    }
}