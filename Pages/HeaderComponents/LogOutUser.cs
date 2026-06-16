using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages.HeaderComponents
{
    public class LogOutUser : BaseClass
    {
        public LogOutUser(IWebDriver driver) : base(WebFactory.driver.Value) { }

        private IWebElement ErrorButton => WebFactory.driver.Value.FindElement(By.CssSelector("[data-test=error]"));

        public async Task LogOutCondition()
        {
            WebDriverWait wait = new WebDriverWait(WebFactory.driver.Value, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a.shopping_cart_link"))).Click();
            wait.Until(d => d.Url.Contains("cart.html"));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("checkout"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("react-burger-menu-btn"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("logout_sidebar_link"))).Click();
            WebFactory.driver.Value.Navigate().Back();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("user-name")));
            await Task.CompletedTask;
        }

        public Task<IWebElement> GetErrorButtonWithWait()
        {
            WebDriverWait wait = new WebDriverWait(WebFactory.driver.Value, TimeSpan.FromSeconds(10));
            return Task.FromResult(wait.Until(_ => ErrorButton));
        }
    }
}
