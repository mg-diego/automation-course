using OpenQA.Selenium;

namespace AutomationFramework.POM.Swaglabs
{
    public class HeaderPage : PageBase
    {
        private By ShoppingCartIcon = By.XPath("//*[@data-icon='shopping-cart']");

        public HeaderPage(IWebDriver driver) : base(driver)
        {
        }

        public void OpenShoppingCart()
        {
            ClickElement(ShoppingCartIcon);
        }
    }
}
