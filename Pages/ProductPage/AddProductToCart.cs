using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages.ProductPage
{
    public class AddProductToCart : BaseClass
    {
        public AddProductToCart(IWebDriver driver) : base(WebFactory.driver.Value) { }

        private By RemoveBagLocator => By.Id("remove-sauce-labs-backpack");

        public Task<bool> IsProductRemoved(By locator)
        {
            try
            {
                return Task.FromResult(!WebFactory.driver.Value.FindElement(locator).Displayed);
            }
            catch (NoSuchElementException)
            {
                return Task.FromResult(true);
            }
        }

        public async Task AddTheProduct()
        {
            WebDriverWait wait = new WebDriverWait(WebFactory.driver.Value, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("add-to-cart-sauce-labs-backpack"))).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("remove-sauce-labs-backpack")));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("add-to-cart-sauce-labs-bike-light"))).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("remove-sauce-labs-bike-light")));
            await Task.CompletedTask;
        }

        public async Task RemoveProducts()
        {
            WebDriverWait wait = new WebDriverWait(WebFactory.driver.Value, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("remove-sauce-labs-backpack"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("remove-sauce-labs-bike-light"))).Click();
            await Task.CompletedTask;
        }

        public async Task NavigateToCart()
        {
            WebDriverWait wait = new WebDriverWait(WebFactory.driver.Value, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a.shopping_cart_link"))).Click();
            wait.Until(d => d.Url.Contains("cart.html"));
            await Task.CompletedTask;
        }

        public Task<string> GetCartCount()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(WebFactory.driver.Value, TimeSpan.FromSeconds(3));
                var badge = wait.Until(d =>
                {
                    try { return d.FindElement(By.CssSelector(".shopping_cart_badge")); }
                    catch (NoSuchElementException) { return null; }
                });
                return Task.FromResult(badge?.Text ?? string.Empty);
            }
            catch
            {
                return Task.FromResult(string.Empty);
            }
        }

        public Task<string> GetBagProductInCartText()
        {
            return Task.FromResult(WebFactory.driver.Value.FindElement(By.Id("remove-sauce-labs-backpack")).Text);
        }

        public Task<string> GetLightProductInCartText()
        {
            return Task.FromResult(WebFactory.driver.Value.FindElement(By.Id("remove-sauce-labs-bike-light")).Text);
        }

        public By GetRemoveBagLocator()
        {
            return RemoveBagLocator;
        }
    }
}
