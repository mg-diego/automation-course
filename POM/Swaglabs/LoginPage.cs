using OpenQA.Selenium;

namespace AutomationFramework.POM.Swaglabs
{
    public class LoginPage : PageBase
    {
        private string LoginUrl = "https://www.saucedemo.com/v1/";

        private By UserNameInput = By.Id("user-name");
        private By PasswordInput = By.Name("password");
        private By SubmitBtn = By.XPath("//*[@type='submit']");
        private By ErrorMessage = By.XPath("//*[@data-test='error']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void SetUserName(string value) 
        {
            SendKeysElement(UserNameInput, value);
        }

        public void SetPassword(string value) 
        {
            SendKeysElement(PasswordInput, value);
        }

        public void ClickSubmitButton()
        {
            ClickElement(SubmitBtn);
        }

        public void CheckUserIsAtLoginPage()
        {
            Assert.AreEqual(LoginUrl, Driver.Url);
        }

        public void CheckUserIsNotAtLoginPage() 
        {
            Assert.AreNotEqual(LoginUrl, Driver.Url);
        }

        public void CheckErrorMessageText(string expectedText) 
        {
            CheckElementText(ErrorMessage, expectedText);
        }
    }
}
