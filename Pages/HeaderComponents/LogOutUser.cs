using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages.HeaderComponents
{
     public  class LogOutUser:BaseClass
    {
        public LogOutUser(IWebDriver driver) : base(WebFactory.driver.Value) { }


        private IWebElement errorButton => WebFactory.driver.Value.FindElement(By.CssSelector("[data-test=error]"));


        public void LogOutCondition()
        {
            WebDriverWait wait = new WebDriverWait(WebFactory.driver.Value, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("shopping_cart_container"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("checkout"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("react-burger-menu-btn"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("logout_sidebar_link"))).Click();

            WebFactory.driver.Value.Navigate().Back();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("user-name")));


        }
        public IWebElement GetErrorButtonWithWait()
        {
            TimeSpan timeout = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(WebFactory.driver.Value, timeout);
            return wait.Until(driver => errorButton);
        }

    }
}
