using OpenQA.Selenium;
using SauseLabPomProject.Credentials;
using SauseLabPomProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SauseLabPomProject.Drivers;


namespace SauseLabPomProject.Pages.PaymentPage
{
    public class CheckOutProduct : BaseClass
    {


        public CheckOutProduct(IWebDriver driver) : base(WebFactory.driver.Value) { }



        private  IWebElement  tshirtPresent=> WebFactory.driver.Value.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        
            
        private IWebElement BagPackPresent => WebFactory.driver.Value.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement NavigateToCart => WebFactory.driver.Value.FindElement(By.Id("shopping_cart_container"));
        private IWebElement CheckoutButton => WebFactory.driver.Value.FindElement(By.Id("checkout"));
        private IWebElement CheckoutVerify => WebFactory.driver.Value.FindElement(By.XPath("//span[@class='title']"));

        public void AddToCheckOut()
        {
           
            tshirtPresent.Click();
            BagPackPresent.Click();
            NavigateToCart.Click(); 
            CheckoutButton.Click();

        }

        public IWebElement GetCheckoutVerifyElement()
        {
            return CheckoutVerify;
        }


    }
}
