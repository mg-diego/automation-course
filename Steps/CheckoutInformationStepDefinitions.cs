using AutomationFramework.POM.Swaglabs;
using AutomationFramework.Webdriver;
using Reqnroll;

namespace AutomationFramework.Steps
{
    [Binding]
    public class CheckoutInformationStepDefinitions
    {
        CheckoutInformationPage checkoutInformationPage;

        public CheckoutInformationStepDefinitions(WebdriverManager webdriverManager)
        {
            var driver = webdriverManager.GetDriver();
            checkoutInformationPage = new CheckoutInformationPage(driver);
        }

        [When("the user sets {string} as name in Checkout Information")]
        public void TheUserSetsName(string name)
        {
            checkoutInformationPage.SetName(name);
        }

        [When("the user sets {string} as surname in Checkout Information")]
        public void TheUserSetsSurname(string surname)
        {
            checkoutInformationPage.SetSurname(surname);
        }

        [When("the user sets {string} as zipcode in Checkout Information")]
        public void TheUserSetsZipCode(string zipCode)
        {
            checkoutInformationPage.SetZipCode(zipCode);
        }

        [When("the user clicks in Continue button")]
        public void TheUserClicksInContinueButton()
        {
            checkoutInformationPage.ClickContinueButton();
        }
    }
}
