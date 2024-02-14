using OpenQA.Selenium;

namespace AutomationFramework.POM.Swaglabs
{
    public class CheckoutInformationPage : PageBase
    {
        private By NameInput = By.Id("first-name");
        private By SurnameInput = By.Id("last-name");
        private By ZipCodeInput = By.Id("postal-code");
        private By ContinueBtn = By.ClassName("cart_button");

        public CheckoutInformationPage(IWebDriver driver) : base(driver)
        {
        }

        public void SetName(string name) => SendKeysElement(NameInput, name);

        public void SetSurname(string name) => SendKeysElement(SurnameInput, name);

        public void SetZipCode(string zipCode) => SendKeysElement(ZipCodeInput, zipCode);

        public void ClickContinueButton() => ClickElement(ContinueBtn);
    }
}
