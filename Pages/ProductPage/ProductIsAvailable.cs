using OpenQA.Selenium;
using SauseLabPomProject;
using SauseLabPomProject.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauseLabPomProject.Pages.ProductPage
{
     public class ProductIsAvailable:BaseClass
    {
       

        public  ProductIsAvailable(IWebDriver driver) : base(WebFactory.driver.Value) { }
        

        private By elementPresent => By.Id("item_4_title_link");
        private By elementIsNotPresent => By.Id("item_8_title_link");


        private bool IsElementPresent(By locator)
        {
            try
            {
                return WebFactory.driver.Value.FindElement(locator).Displayed;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool checkProductAvl()
        { 
            
            return IsElementPresent(elementPresent); 
            
        }
        public bool checkProductNotAvl()
        {
            return !IsElementPresent(elementIsNotPresent);
        }
        
    }
}
