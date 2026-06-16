using OpenQA.Selenium;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages.PaymentPage
{
    public class CheckOutProduct : BaseClass
    {
        public CheckOutProduct(IWebDriver driver) : base(WebFactory.driver.Value) { }

        private IWebElement TshirtPresent => WebFactory.driver.Value.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        private IWebElement BagPackPresent => WebFactory.driver.Value.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement NavigateToCart => WebFactory.driver.Value.FindElement(By.Id("shopping_cart_container"));
        private IWebElement CheckoutButton => WebFactory.driver.Value.FindElement(By.Id("checkout"));
        private IWebElement CheckoutVerify => WebFactory.driver.Value.FindElement(By.XPath("//span[@class='title']"));

        public async Task AddToCheckOut()
        {
            TshirtPresent.Click();
            BagPackPresent.Click();
            NavigateToCart.Click();
            CheckoutButton.Click();
            await Task.CompletedTask;
        }

        public Task<IWebElement> GetCheckoutVerifyElement()
        {
            return Task.FromResult(CheckoutVerify);
        }
    }
}
