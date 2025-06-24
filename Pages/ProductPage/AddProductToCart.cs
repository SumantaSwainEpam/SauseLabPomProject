using OpenQA.Selenium;
using SauseLabPomProject.Credentials;
using SauseLabPomProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages.ProductPage
{
    public class AddProductToCart:BaseClass
    {

        public AddProductToCart(IWebDriver driver) : base(WebFactory.driver.Value) { }
       


        private IWebElement bagPack => WebFactory.driver.Value.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement bikeLight => WebFactory.driver.Value.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        private IWebElement rmvBagLogo => WebFactory.driver.Value.FindElement(By.Id("remove-sauce-labs-backpack"));
        private IWebElement rmvLightLogo => WebFactory.driver.Value.FindElement(By.Id("remove-sauce-labs-bike-light"));
        private By removeBag => By.Id("remove-sauce-labs-backpack");
        private IWebElement navigateToCart => WebFactory.driver.Value.FindElement(By.Id("shopping_cart_container"));

        public IWebElement cartCount => WebFactory.driver.Value.FindElement(By.CssSelector("a[class=shopping_cart_link]"));



        public bool IsProductRemoved(By locator)
        {
            try
            {
                return !WebFactory.driver.Value.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }


        public void AddTheProduct()
        {   
            bagPack.Click();
            bikeLight.Click();
        }

        public void RemoveProducts()
        {
            rmvBagLogo.Click();
            rmvLightLogo.Click();
        }

        public void NavigateToCart()
        {
            navigateToCart.Click();
        }
        public string GetCartCount()
        {
            return cartCount.Text;
        }

        public string GetBagProductInCartText()
        {
            return rmvBagLogo.Text;
        }
         
        
        public string GetLightProductInCartText()
        {
            return rmvLightLogo.Text;
        }

        public By GetRemoveBag()
        {
            return removeBag;
        }



    }
}
