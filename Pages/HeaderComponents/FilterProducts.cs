using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages.HeaderComponents
{
    public class FilterProducts : BaseClass
    {
        public FilterProducts(IWebDriver driver) : base(WebFactory.driver.Value) { }

        private IWebElement Filter => WebFactory.driver.Value.FindElement(By.CssSelector("[class=product_sort_container]"));
        private IWebElement Product1 => WebFactory.driver.Value.FindElement(By.Id("item_3_title_link"));
        private IWebElement Product2 => WebFactory.driver.Value.FindElement(By.Id("item_2_title_link"));

        public async Task ApplyFilter()
        {
            Filter.Click();
            SelectElement selectElement = new SelectElement(Filter);
            selectElement.SelectByIndex(1);
            Filter.Click();
            await Task.CompletedTask;
        }

        public Task<IWebElement> GetProduct1()
        {
            return Task.FromResult(Product1);
        }

        public Task<IWebElement> GetProduct2()
        {
            return Task.FromResult(Product2);
        }
    }
}
