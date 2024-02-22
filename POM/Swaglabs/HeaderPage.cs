using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;

namespace AutomationFramework.POM.Swaglabs
{
    public class HeaderPage : PageBase
    {
        private By ShoppingCartIcon = By.Id("shopping_cart_container");
        public HeaderPage(IWebDriver driver) : base(driver)
        {
        }

        public void OpenShoppingCart()
        {
            ClickElement(ShoppingCartIcon);
        }

        public void CheckNumberOfItemsInCart(int numberOfItems)
        {

            CheckElementText(ShoppingCartIcon, numberOfItems.ToString());
        }
    }
}
