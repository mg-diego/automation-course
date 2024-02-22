using System;
using AutomationFramework.POM.Swaglabs;
using AutomationFramework.Webdriver;
using Reqnroll;

namespace AutomationFramework.Steps
{
    [Binding]
    public class LoginStepDefinitions
    {
        private LoginPage loginPage;

        LoginStepDefinitions(WebdriverManager webDriverManager)
        {
            var driver = webDriverManager.GetDriver();
            loginPage = new LoginPage(driver);
        }


        [Given("the user enters username {string}")]
        public void GivenTheUserEntersUsername(string username)
        {
            this.loginPage.SetUserName(username);
        }

        [Given("the user enters password {string}")]
        public void GivenTheUserEntersPassword(string password)
        {
            this.loginPage.SetPassword(password);
        }

        [When("the user submit a login action")]
        [Given("the user submit a login action")]
        public void WhenTheUserClicksSubmit()
        {
            this.loginPage.ClickSubmitButton();
        }

        [Then("the user can login")]
        public void ThenTheUserCanLogin()
        {
            this.loginPage.CheckUserIsNotAtLoginPage();
        }

        [Then("the user can see the next error message")]
        public void ThenTheUserCanSeeTheNextErrorMessage(string multilineText)
        {
            this.loginPage.CheckErrorMessageText(multilineText);
        }

    }
}
