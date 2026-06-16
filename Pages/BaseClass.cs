using OpenQA.Selenium;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages
{
    public class BaseClass
    {
        public BaseClass(IWebDriver driver)
        {
            WebFactory.driver.Value = driver;
        }
    }
}
