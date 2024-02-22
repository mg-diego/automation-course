using OpenQA.Selenium;

namespace AutomationFramework.POM.Swaglabs
{
    public class LoginPage : PageBase
    {

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
            ElementIsPresent(UserNameInput);
            ElementIsPresent(PasswordInput);
            ElementIsPresent(SubmitBtn);
        }

        public void CheckUserIsNotAtLoginPage() 
        {
            ElementIsNotPresent(UserNameInput);
            ElementIsNotPresent(PasswordInput);
            ElementIsNotPresent(SubmitBtn);
        }

        public void CheckErrorMessageText(string expectedText) 
        {
            CheckElementText(ErrorMessage, expectedText);
        }
    }
}
