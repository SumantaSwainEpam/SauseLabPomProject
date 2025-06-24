using OpenQA.Selenium;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using SauseLabPomProject.Tests;
using SauseLabPomProject.Drivers;


namespace SauseLabPomProject.Pages.ScreenshotsPage
{
     public  class TakeScreenShot
    {
         
        //private readonly IWebDriver _driver;
        public TakeScreenShot(IWebDriver driver)
        {
            WebFactory.driver.Value = driver;
        }


        public void CaptureScreenshot(string testName)
        {
          
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)WebFactory.driver.Value).GetScreenshot();
                string timestamp = DateTime.Now.ToString("dd_MM_yyyy_HHmmss");
                string filterTestName = Regex.Replace(testName, @"[<>:""/\\|?*]", "_");
                var parentDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                var ScreenshotDir = Path.Combine(parentDir, "Error_Screenshots");

                if (!Directory.Exists(ScreenshotDir))
                {
                    Directory.CreateDirectory(ScreenshotDir);
                }
                var fileName = $"{filterTestName}_{timestamp}.Png";
                var filePath=Path.Combine(ScreenshotDir, fileName);
                screenshot.SaveAsFile(filePath);
                Console.WriteLine($"Screenshot saved at: {filePath}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
