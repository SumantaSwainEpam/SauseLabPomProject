using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages.PaymentPage
{
    public class CancelOrder : BaseClass
    {
        public CancelOrder(IWebDriver driver) : base(WebFactory.driver.Value) { }

        private IWebElement FirstName => WebFactory.driver.Value.FindElement(By.Id("first-name"));
        private IWebElement LastName => WebFactory.driver.Value.FindElement(By.Id("last-name"));
        private IWebElement ZipCode => WebFactory.driver.Value.FindElement(By.Id("postal-code"));
        private IWebElement ContinueOrder => WebFactory.driver.Value.FindElement(By.Id("continue"));
        private IWebElement CancelButton => WebFactory.driver.Value.FindElement(By.Id("cancel"));
        private IWebElement ProductPageTitle => WebFactory.driver.Value.FindElement(By.CssSelector("span[class='title']"));

        public async Task AddProductsToCart()
        {
            WebDriverWait wait = new WebDriverWait(WebFactory.driver.Value, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("add-to-cart-sauce-labs-backpack"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("add-to-cart-sauce-labs-bike-light"))).Click();
            await Task.CompletedTask;
        }

        public async Task ProceedToCheckout()
        {
            WebDriverWait wait = new WebDriverWait(WebFactory.driver.Value, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a.shopping_cart_link"))).Click();
            wait.Until(d => d.Url.Contains("cart.html"));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("checkout"))).Click();
            await Task.CompletedTask;
        }

        public async Task EnterCheckoutInformation(string firstName, string lastName, string zipCode)
        {
            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            ZipCode.SendKeys(zipCode);
            await Task.CompletedTask;
        }

        public async Task ClickCancelButton()
        {
            ContinueOrder.Click();
            CancelButton.Click();
            await Task.CompletedTask;
        }

        public Task<string> GetProductPageTitle()
        {
            return Task.FromResult(ProductPageTitle.Text);
        }

        public async Task CompleteOrderCancellation(string firstName, string lastName, string zipCode)
        {
            await AddProductsToCart();
            await ProceedToCheckout();
            await EnterCheckoutInformation(firstName, lastName, zipCode);
            await ClickCancelButton();
        }
    }
}
