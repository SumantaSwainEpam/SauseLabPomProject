using OpenQA.Selenium;
using SauseLabPomProject.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using SauseLabPomProject.Drivers;


namespace SauseLabPomProject.Pages.PaymentPage
{
     public class OrderPlaced:BaseClass
    {
        public OrderPlaced(IWebDriver driver) : base(WebFactory.driver.Value) { }
        

        private IWebElement bagPack => WebFactory.driver.Value.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement light => WebFactory.driver.Value.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        private IWebElement navigateToCart => WebFactory.driver.Value.FindElement(By.Id("shopping_cart_container"));
        private IWebElement firstName => WebFactory.driver.Value.FindElement(By.Id("first-name"));
        private IWebElement lastName => WebFactory.driver.Value.FindElement(By.Id("last-name"));
        private IWebElement zipCode => WebFactory.driver.Value.FindElement(By.Id("postal-code"));
        private IWebElement contOrder => WebFactory.driver.Value.FindElement(By.Id("continue"));
        private IWebElement finish => WebFactory.driver.Value.FindElement(By.Id("finish"));
        private IWebElement productPageElement => WebFactory.driver.Value.FindElement(By.CssSelector(".complete-header"));
        private IWebElement checkOut => WebFactory.driver.Value.FindElement(By.Id("checkout"));

       
        public void AddProductsToCart()
        {
            bagPack.Click();
            light.Click();
        }

        public void NavigateToCart()
        {
            navigateToCart.Click();
        }

        public void ProceedToCheckout()
        {
            checkOut.Click(); 
        }

        
        public void EnterCheckoutInformation(string firstNameValue, string lastNameValue, string zipCodeValue)
        {
            firstName.SendKeys(firstNameValue); 
            lastName.SendKeys(lastNameValue); 
            zipCode.SendKeys(zipCodeValue); 
            contOrder.Click(); 
        }

       
        public void PlaceOrder()
        {
            ProceedToCheckout(); 
            EnterCheckoutInformation("Sumanta", "Swain", "500081"); 
            finish.Click(); 
        }

       
        public string GetProductPageTitle()
        {
            return productPageElement.Text; 
        }

    }
}
