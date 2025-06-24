using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages
{
     public class BaseClass
    {
        //protected  IWebDriver _driver;

        public BaseClass(IWebDriver driver)
        {
            WebFactory.driver.Value = driver;

        }
    }
}
