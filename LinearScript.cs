using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace backup
{
    [TestClass]
    public class LinearScript
    {
        private ChromeDriver driver;
        private string TheInternetTablesUrl = "https://the-internet.herokuapp.com/tables";
        private string TheInternetCheckboxUrl = "https://the-internet.herokuapp.com/checkboxes";
        private string SwagLabsUrl = "https://www.saucedemo.com/v1/";

        [TestInitialize]
        public void Setup() {
            this.driver = new ChromeDriver(ChromeDriverService.CreateDefaultService("C:\\temp\\drivers"), new ChromeOptions(), TimeSpan.FromSeconds(15));
            this.driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TearDown()
        {
            this.driver.Dispose();
            this.driver.Quit();
        }

        [TestMethod]
        public void ValidLogin()
        {
            this.driver.Navigate().GoToUrl(SwagLabsUrl);

            var userNameInput = this.driver.FindElement(By.Id("user-name"));
            var passwordInput = this.driver.FindElement(By.Name("password"));
            var submitBtn = this.driver.FindElement(By.XPath("//*[@type='submit']"));

            userNameInput.SendKeys("standard_user");
            passwordInput.SendKeys("secret_sauce");

            submitBtn.Click();

            Assert.AreEqual("https://www.saucedemo.com/v1/inventory.html", driver.Url);
        }

        [TestMethod]
        public void InvalidLogin() 
        {
            this.driver.Navigate().GoToUrl(SwagLabsUrl);

            var userNameInput = this.driver.FindElement(By.Id("user-name"));
            var passwordInput = this.driver.FindElement(By.Name("password"));
            var submitBtn = this.driver.FindElement(By.XPath("//*[@type='submit']"));

            userNameInput.SendKeys("diego");
            passwordInput.SendKeys("diego");

            submitBtn.Click();

            var errorMessage = this.driver.FindElement(By.XPath("//*[@data-test='error']"));

            Assert.AreEqual("https://www.saucedemo.com/v1/", driver.Url);
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", errorMessage.Text);
        }

        [TestMethod]
        public void SlowLogin()
        {
            this.driver.Navigate().GoToUrl(SwagLabsUrl);

            var userNameInput = this.driver.FindElement(By.Id("user-name"));
            var passwordInput = this.driver.FindElement(By.Name("password"));
            var submitBtn = this.driver.FindElement(By.XPath("//*[@type='submit']"));

            userNameInput.SendKeys("performance_glitch_user");
            passwordInput.SendKeys("secret_sauce");

            submitBtn.Click();

            // Modify the commandTimeout value from 3 to 15 seconds at driver initialization, line 16
            Assert.AreEqual("https://www.saucedemo.com/v1/inventory.html", driver.Url);
        }

        [TestMethod]
        public void CheckAmountOfProducts()
        {
            this.driver.Navigate().GoToUrl(SwagLabsUrl);

            var userNameInput = this.driver.FindElement(By.Id("user-name"));
            var passwordInput = this.driver.FindElement(By.Name("password"));
            var submitBtn = this.driver.FindElement(By.XPath("//*[@type='submit']"));

            userNameInput.SendKeys("standard_user");
            passwordInput.SendKeys("secret_sauce");

            submitBtn.Click();

            var products = this.driver.FindElements(By.XPath("//img[@class='inventory_item_img']"));

            Assert.AreEqual(6, products.Count);
        }

        [TestMethod]
        public void BuyAProduct()
        {
            var productName = "Sauce Labs Fleece Jacket";
            var expectedQuantity = 1;

            this.driver.Navigate().GoToUrl(SwagLabsUrl);

            // Login
            var userNameInput = this.driver.FindElement(By.Id("user-name"));
            var passwordInput = this.driver.FindElement(By.Name("password"));
            var submitBtn = this.driver.FindElement(By.XPath("//*[@type='submit']"));
            userNameInput.SendKeys("standard_user");
            passwordInput.SendKeys("secret_sauce");
            submitBtn.Click();

            // Select product
            var products = this.driver.FindElements(By.ClassName("inventory_item_name"));
            var productIndex = products.IndexOf(products.FirstOrDefault(x => x.Text == productName));
            var addToCartBtnList = this.driver.FindElements(By.ClassName("btn_inventory"));
            addToCartBtnList[productIndex].Click();

            // Navigate to cart and check product
            this.driver.FindElement(By.XPath("//*[@data-icon='shopping-cart']")).Click();
            var productsAtCart = this.driver.FindElements(By.ClassName("inventory_item_name"));
            var cartProductIndex = productsAtCart.IndexOf(productsAtCart.FirstOrDefault(x => x.Text == productName));
            var productQuantityList = this.driver.FindElements(By.ClassName("cart_quantity"));
            Assert.AreEqual(expectedQuantity.ToString(), productQuantityList[cartProductIndex].Text);
            this.driver.FindElement(By.ClassName("checkout_button")).Click();        

            // Checkout: Personal Info
            this.driver.FindElement(By.Id("first-name")).SendKeys("Diego");
            this.driver.FindElement(By.Id("last-name")).SendKeys("Martinez");
            this.driver.FindElement(By.Id("postal-code")).SendKeys("123");
            this.driver.FindElement(By.ClassName("cart_button")).Click();

            // Checkout: Overview
            var overviewProducts = this.driver.FindElements(By.ClassName("inventory_item_name"));
            var overviewProductIndex = overviewProducts.IndexOf(overviewProducts.FirstOrDefault(x => x.Text == productName));
            var overviewProductQuantityList = this.driver.FindElements(By.ClassName("summary_quantity"));
            Assert.AreEqual(expectedQuantity.ToString(), overviewProductQuantityList[overviewProductIndex].Text);
            this.driver.FindElement(By.ClassName("cart_button")).Click();

            // Order finished
            Assert.AreEqual(
                "THANK YOU FOR YOUR ORDER",
                this.driver.FindElement(By.ClassName("complete-header")).Text
            );
            Assert.AreEqual(
                "Your order has been dispatched, and will arrive just as fast as the pony can get there!",
                this.driver.FindElement(By.ClassName("complete-text")).Text
            );
        }

        [TestMethod]
        public void CheckUsersBy50Due() 
        {
            this.driver.Navigate().GoToUrl(TheInternetTablesUrl);

            Thread.Sleep(2000); //BAD PRACTICE
            var table = this.driver.FindElement(By.Id("table1"));
            var headers = table.FindElements(By.XPath(".//thead/tr/th"));
            var rows = table.FindElements(By.XPath("./tbody/tr"));

            var headerIndex = -1;
            // FOREACH APPROACH
            /*foreach (var header in headers) 
            {
                if (header.Text == "Due")
                {
                    headerIndex = headers.IndexOf(header);
                    continue;
                }
            }*/

            // LINQ approach
            headerIndex = headers.Select(x => x.Text).ToList().IndexOf("Due");

            var usersWith50Due = new List<string>();
            // FOREACH APPROACH
            /*foreach (var row in rows)
            {
                var cells = row.FindElements(By.XPath("./td"));
                if (cells[headerIndex].Text.Contains("50"))
                {
                    usersWith50Due.Add(cells[1].Text);
                }
            }*/

            // LINQ approach
            var rowsWithMatches = rows.Where(x => x.FindElements(By.XPath("./td")).Any(y => y.Text.Contains("50"))).ToList();
            rowsWithMatches.ForEach(match => usersWith50Due.Add(match.FindElements(By.XPath("./td"))[1].Text));

            Assert.AreEqual("John", usersWith50Due[0]);
            Assert.AreEqual("Tim", usersWith50Due[1]);
        }

        [TestMethod]
        public void CheckTableCanBeSorted()
        {
            this.driver.Navigate().GoToUrl(TheInternetTablesUrl);

            Thread.Sleep(2000); //BAD PRACTICE
            var table = this.driver.FindElement(By.Id("table1"));
            var headers = table.FindElements(By.XPath("./thead/tr/th"));
            var rows = table.FindElements(By.XPath("./tbody/tr"));

            headers.Where(x => x.Text == "First Name").FirstOrDefault().Click();
            var firstNameHeaderIndex = headers.Select(x => x.Text).ToList().IndexOf("First Name");

            var headerFirstNameValues = rows.Select(x => x.FindElements(By.XPath("./td"))[firstNameHeaderIndex].Text).ToList();

            Assert.AreEqual(headerFirstNameValues[0], "John");
            Assert.AreEqual(headerFirstNameValues[1], "Frank");
            Assert.AreEqual(headerFirstNameValues[2], "Jason");
            Assert.AreEqual(headerFirstNameValues[3], "Tim");
        }

        [TestMethod]
        public void ClickAndVerifyCheckbox()
        {
            this.driver.Navigate().GoToUrl(TheInternetCheckboxUrl);

            Thread.Sleep(2000); //BAD PRACTICE
            var checkBoxList = this.driver.FindElements(By.XPath("//*[@type='checkbox']")).ToList();

            checkBoxList.ForEach(checkbox => checkbox.Click());

            Assert.IsTrue(checkBoxList[0].Selected);
            Assert.IsFalse(checkBoxList[1].Selected);
        }
    }
}