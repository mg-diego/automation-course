using OpenQA.Selenium;

namespace AutomationFramework.POM.Swaglabs
{
    public class ShoppingCartPage : PageBase
    {
        private By CartProductName = By.ClassName("inventory_item_name");
        private By CartProductQuantity = By.ClassName("cart_quantity");
        private By CheckoutBtn = By.ClassName("checkout_button");

        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickCheckoutButton()
        {
            ClickElement(CheckoutBtn);
        }

        public void CheckProductIsAtCart(string productName, int expectedProductQuantity)
        {
            var products = Driver.FindElements(CartProductName);
            var productIndex = products.IndexOf(products.FirstOrDefault(x => x.Text == productName));
            var productQuantityList = Driver.FindElements(CartProductQuantity);
            Assert.AreEqual(expectedProductQuantity.ToString(), productQuantityList[productIndex].Text);
        }

    }
}
