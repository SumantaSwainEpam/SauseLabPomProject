using OpenQA.Selenium;
using SauseLabPomProject.Drivers;
using SauseLabPomProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauseLabPomProject.Util
{
    public  class PageFactory
    {
        //private readonly IWebDriver _driver;

        public PageFactory(IWebDriver driver)
        {
            WebFactory.driver.Value = driver;
            
        }

        public T CreatePage<T>() where T : BaseClass
        {
            return (T)Activator.CreateInstance(typeof(T), WebFactory.driver.Value);
        }

    }
}
