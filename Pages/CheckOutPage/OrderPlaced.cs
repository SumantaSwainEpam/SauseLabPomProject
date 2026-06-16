using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages.PaymentPage
{
    public class OrderPlaced : BaseClass
    {
        public OrderPlaced(IWebDriver driver) : base(WebFactory.driver.Value) { }

        private IWebElement FirstName => WebFactory.driver.Value.FindElement(By.Id("first-name"));
        private IWebElement LastName => WebFactory.driver.Value.FindElement(By.Id("last-name"));
        private IWebElement ZipCode => WebFactory.driver.Value.FindElement(By.Id("postal-code"));
        private IWebElement ContinueOrder => WebFactory.driver.Value.FindElement(By.Id("continue"));
        private IWebElement FinishButton => WebFactory.driver.Value.FindElement(By.Id("finish"));
        private IWebElement OrderCompleteHeader => WebFactory.driver.Value.FindElement(By.CssSelector(".complete-header"));

        public async Task AddProductsToCart()
        {
            WebDriverWait wait = new WebDriverWait(WebFactory.driver.Value, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("add-to-cart-sauce-labs-backpack"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("add-to-cart-sauce-labs-bike-light"))).Click();
            await Task.CompletedTask;
        }

        public async Task NavigateToCart()
        {
            WebDriverWait wait = new WebDriverWait(WebFactory.driver.Value, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a.shopping_cart_link"))).Click();
            wait.Until(d => d.Url.Contains("cart.html"));
            await Task.CompletedTask;
        }

        public async Task ProceedToCheckout()
        {
            WebDriverWait wait = new WebDriverWait(WebFactory.driver.Value, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("checkout"))).Click();
            await Task.CompletedTask;
        }

        public async Task EnterCheckoutInformation(string firstName, string lastName, string zipCode)
        {
            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            ZipCode.SendKeys(zipCode);
            ContinueOrder.Click();
            await Task.CompletedTask;
        }

        public async Task PlaceOrder()
        {
            await ProceedToCheckout();
            await EnterCheckoutInformation("Sumanta", "Swain", "500081");
            FinishButton.Click();
        }

        public Task<string> GetProductPageTitle()
        {
            return Task.FromResult(OrderCompleteHeader.Text);
        }
    }
}
