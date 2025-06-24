using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages.HeaderComponents
{
     public  class FilterProducts:BaseClass
    {


        public FilterProducts(IWebDriver driver) : base(WebFactory.driver.Value) { }

        private IWebElement filter => WebFactory.driver.Value.FindElement(By.CssSelector("[class=product_sort_container]"));
        private IWebElement product1 => WebFactory.driver.Value.FindElement(By.Id("item_3_title_link"));
        private IWebElement product2 => WebFactory.driver.Value.FindElement(By.Id("item_2_title_link"));

        
        public void ApplyFilter()
        {
            filter.Click();
            SelectElement selectElement = new SelectElement(filter);
            selectElement.SelectByIndex(1);
            filter.Click();


        }

        public IWebElement GetProduct1()
        {
            return product1;
        }
        public IWebElement GetProduct2()
        {
            return product2;
        }





    }
}
