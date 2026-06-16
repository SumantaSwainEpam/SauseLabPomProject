using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages.PaymentPage
{
    public class CheckOutProduct : BaseClass
    {
        public CheckOutProduct(IWebDriver driver) : base(WebFactory.driver.Value) { }

        private IWebElement CheckoutVerify => WebFactory.driver.Value.FindElement(By.XPath("//span[@class='title']"));

        public async Task AddToCheckOut()
        {
            WebDriverWait wait = new WebDriverWait(WebFactory.driver.Value, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("add-to-cart-sauce-labs-backpack"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a.shopping_cart_link"))).Click();
            wait.Until(d => d.Url.Contains("cart.html"));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("checkout"))).Click();
            await Task.CompletedTask;
        }

        public Task<IWebElement> GetCheckoutVerifyElement()
        {
            return Task.FromResult(CheckoutVerify);
        }
    }
}
