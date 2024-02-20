using OpenQA.Selenium;

namespace AutomationFramework.POM.Swaglabs
{
    public class ProductsPage : PageBase
    {
        private By ProductImages = By.XPath("//img[@class='inventory_item_img']");

        private By ProductName = By.ClassName("inventory_item_name");

        private By AddToCartBtn = By.ClassName("btn_inventory");

        public ProductsPage(IWebDriver driver) : base(driver)
        {
        }

        public void CheckAmountOfProducts(int expectedAmount)
        {
            var elements = Driver.FindElements(ProductImages);
            Assert.AreEqual(expectedAmount, elements.Count);
        }

        public void CheckUserIsAtProductsPage()
        {
            ElementIsPresent(ProductImages);
            ElementIsPresent(ProductName);
            ElementIsPresent(AddToCartBtn);

        }

        public void AddProductToCartByName(string productName)
        {
            var products = Driver.FindElements(ProductName);
            var productIndex = products.IndexOf(products.FirstOrDefault(x => x.Text == productName));
            ClickElement(AddToCartBtn, productIndex);
        }
    }
}
