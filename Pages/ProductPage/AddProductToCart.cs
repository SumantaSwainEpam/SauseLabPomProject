using OpenQA.Selenium;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages.ProductPage
{
    public class AddProductToCart : BaseClass
    {
        public AddProductToCart(IWebDriver driver) : base(WebFactory.driver.Value) { }

        private IWebElement BagPack => WebFactory.driver.Value.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement BikeLight => WebFactory.driver.Value.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        private IWebElement RemoveBagPack => WebFactory.driver.Value.FindElement(By.Id("remove-sauce-labs-backpack"));
        private IWebElement RemoveBikeLight => WebFactory.driver.Value.FindElement(By.Id("remove-sauce-labs-bike-light"));
        private By RemoveBagLocator => By.Id("remove-sauce-labs-backpack");
        private IWebElement CartContainer => WebFactory.driver.Value.FindElement(By.Id("shopping_cart_container"));
        public IWebElement CartCount => WebFactory.driver.Value.FindElement(By.CssSelector("a[class=shopping_cart_link]"));

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
            BagPack.Click();
            BikeLight.Click();
            await Task.CompletedTask;
        }

        public async Task RemoveProducts()
        {
            RemoveBagPack.Click();
            RemoveBikeLight.Click();
            await Task.CompletedTask;
        }

        public async Task NavigateToCart()
        {
            CartContainer.Click();
            await Task.CompletedTask;
        }

        public Task<string> GetCartCount()
        {
            return Task.FromResult(CartCount.Text);
        }

        public Task<string> GetBagProductInCartText()
        {
            return Task.FromResult(RemoveBagPack.Text);
        }

        public Task<string> GetLightProductInCartText()
        {
            return Task.FromResult(RemoveBikeLight.Text);
        }

        public By GetRemoveBagLocator()
        {
            return RemoveBagLocator;
        }
    }
}
