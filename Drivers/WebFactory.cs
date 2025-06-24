using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V125.Debugger;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauseLabPomProject.Drivers
{
    public  static class WebFactory
    {
        public static readonly ThreadLocal<IWebDriver> driver= new ThreadLocal<IWebDriver>();

        public static IWebDriver CreateDriver(string browserName)
        {

             

            try
            {
                switch (browserName.ToLower()) {

                case "chrome":
                   ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--disable-popup-blocking");
                    options.AddArguments("--headless");
                    driver.Value = new ChromeDriver(options);
                        break;
                case "edge":
                        EdgeOptions edgeOptions=new EdgeOptions();
                        edgeOptions.AddArgument("--disable-popup-blocking");
                        edgeOptions.AddArguments("--headless");
                        driver.Value =new EdgeDriver(edgeOptions); 

                        break;

                case "firefox":
                        FirefoxOptions fxOptions=new FirefoxOptions();
                        fxOptions.AddArgument("--disable-popup-blocking");
                        fxOptions.AddArguments("--headless");
                        driver.Value =new FirefoxDriver(fxOptions);
                        break;

                 default:
                        throw new ArgumentException();

                }
                driver.Value.Manage().Window.Maximize();
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return driver.Value;

        }
    }
}
