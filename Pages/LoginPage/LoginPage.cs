using OpenQA.Selenium;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages
{
    public class LoginPage : BaseClass
    {
        public LoginPage(IWebDriver driver) : base(WebFactory.driver.Value) { }

        private IWebElement UserNameField => WebFactory.driver.Value.FindElement(By.Id("user-name"));
        private IWebElement PasswordField => WebFactory.driver.Value.FindElement(By.Id("password"));
        private IWebElement LoginButton => WebFactory.driver.Value.FindElement(By.Id("login-button"));
        private IWebElement AppLogo => WebFactory.driver.Value.FindElement(By.CssSelector(".app_logo"));

        public async Task UserLogin(string username, string password)
        {
            UserNameField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();
            await Task.CompletedTask;
        }

        public Task<string> GetAppLogoText()
        {
            return Task.FromResult(AppLogo.Text);
        }

        public Task<bool> IsLoginButtonDisplayed()
        {
            return Task.FromResult(LoginButton.Displayed);
        }
    }
}
