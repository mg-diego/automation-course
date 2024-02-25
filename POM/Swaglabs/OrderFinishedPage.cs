using OpenQA.Selenium;

namespace AutomationFramework.POM.Swaglabs
{
    public class OrderFinishedPage : PageBase
    {
        private By OrderFinishedHeader = By.ClassName("complete-header");
        private By OrderFinishedText = By.ClassName("complete-text");


        public OrderFinishedPage(IWebDriver driver) : base(driver)
        {
        }

        public void CheckOrderFinishedAppears()
        {
            CheckElementText(OrderFinishedHeader, "Thank you for your order!");
            CheckElementText(OrderFinishedText, "Your order has been dispatched, and will arrive just as fast as the pony can get there!");
        }
    }
}
