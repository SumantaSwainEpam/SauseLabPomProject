using OpenQA.Selenium;
using SauseLabPomProject.Drivers;
using SauseLabPomProject.Pages;

namespace SauseLabPomProject.Util
{
    public class PageFactory
    {
        public PageFactory(IWebDriver driver)
        {
            WebFactory.driver.Value = driver;
        }

        public T CreatePage<T>() where T : BaseClass
        {
            return (T)Activator.CreateInstance(typeof(T), WebFactory.driver.Value)!;
        }
    }
}
