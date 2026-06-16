using OpenQA.Selenium;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages.PaymentPage
{
    public class OrderPlaced : BaseClass
    {
        public OrderPlaced(IWebDriver driver) : base(WebFactory.driver.Value) { }

        private IWebElement BagPack => WebFactory.driver.Value.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement BikeLight => WebFactory.driver.Value.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        private IWebElement CartContainer => WebFactory.driver.Value.FindElement(By.Id("shopping_cart_container"));
        private IWebElement FirstName => WebFactory.driver.Value.FindElement(By.Id("first-name"));
        private IWebElement LastName => WebFactory.driver.Value.FindElement(By.Id("last-name"));
        private IWebElement ZipCode => WebFactory.driver.Value.FindElement(By.Id("postal-code"));
        private IWebElement ContinueOrder => WebFactory.driver.Value.FindElement(By.Id("continue"));
        private IWebElement FinishButton => WebFactory.driver.Value.FindElement(By.Id("finish"));
        private IWebElement OrderCompleteHeader => WebFactory.driver.Value.FindElement(By.CssSelector(".complete-header"));
        private IWebElement CheckOut => WebFactory.driver.Value.FindElement(By.Id("checkout"));

        public async Task AddProductsToCart()
        {
            BagPack.Click();
            BikeLight.Click();
            await Task.CompletedTask;
        }

        public async Task NavigateToCart()
        {
            CartContainer.Click();
            await Task.CompletedTask;
        }

        public async Task ProceedToCheckout()
        {
            CheckOut.Click();
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
