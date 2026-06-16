using OpenQA.Selenium;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages.PaymentPage
{
    public class CancelOrder : BaseClass
    {
        public CancelOrder(IWebDriver driver) : base(WebFactory.driver.Value) { }

        private IWebElement BagPack => WebFactory.driver.Value.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement BikeLight => WebFactory.driver.Value.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        private IWebElement CartContainer => WebFactory.driver.Value.FindElement(By.Id("shopping_cart_container"));
        private IWebElement FirstName => WebFactory.driver.Value.FindElement(By.Id("first-name"));
        private IWebElement LastName => WebFactory.driver.Value.FindElement(By.Id("last-name"));
        private IWebElement ZipCode => WebFactory.driver.Value.FindElement(By.Id("postal-code"));
        private IWebElement ContinueOrder => WebFactory.driver.Value.FindElement(By.Id("continue"));
        private IWebElement CheckOut => WebFactory.driver.Value.FindElement(By.Id("checkout"));
        private IWebElement CancelButton => WebFactory.driver.Value.FindElement(By.Id("cancel"));
        private IWebElement ProductPageTitle => WebFactory.driver.Value.FindElement(By.CssSelector("span[class='title']"));

        public async Task AddProductsToCart()
        {
            BagPack.Click();
            BikeLight.Click();
            await Task.CompletedTask;
        }

        public async Task ProceedToCheckout()
        {
            CartContainer.Click();
            CheckOut.Click();
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
