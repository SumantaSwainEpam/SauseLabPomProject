using OpenQA.Selenium;
using SauseLabPomProject;
using SauseLabPomProject.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauseLabPomProject.Pages
{
    public class LoginPage : BaseClass
    {
       
        public LoginPage(IWebDriver driver) : base(WebFactory.driver.Value) { }
       

        private IWebElement userName => WebFactory.driver.Value.FindElement(By.Id("user-name"));
        private IWebElement passWord => WebFactory.driver.Value.FindElement(By.Id("password"));
        private IWebElement logIn => WebFactory.driver.Value.FindElement(By.Id("login-button"));
        private IWebElement appLogo => WebFactory.driver.Value.FindElement(By.CssSelector(".app_logo"));
        private IWebElement loginButtoon => WebFactory.driver.Value.FindElement(By.Id("login-button"));


        internal void UserLogin(string Username, string Password)
        {   
           
            userName.SendKeys(Username);
            passWord.SendKeys(Password);
            logIn.Click();

        }

        public string GetAppLogoText()
        {
            return appLogo.Text;
        }

        public bool isLoginButtonDisplayed()
        {
            return loginButtoon.Displayed;
        }

        
    }
}
