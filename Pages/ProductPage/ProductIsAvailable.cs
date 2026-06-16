using OpenQA.Selenium;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages.ProductPage
{
    public class ProductIsAvailable : BaseClass
    {
        public ProductIsAvailable(IWebDriver driver) : base(WebFactory.driver.Value) { }

        private By ElementPresent => By.Id("item_4_title_link");
        private By ElementIsNotPresent => By.Id("item_8_title_link");

        private Task<bool> IsElementPresent(By locator)
        {
            try
            {
                return Task.FromResult(WebFactory.driver.Value.FindElement(locator).Displayed);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public async Task<bool> CheckProductAvailable()
        {
            return await IsElementPresent(ElementPresent);
        }

        public async Task<bool> CheckProductNotAvailable()
        {
            return !await IsElementPresent(ElementIsNotPresent);
        }
    }
}
