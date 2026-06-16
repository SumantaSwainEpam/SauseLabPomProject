using OpenQA.Selenium;
using System.Text.RegularExpressions;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Pages.ScreenshotsPage
{
    public class TakeScreenShot
    {
        public TakeScreenShot(IWebDriver driver)
        {
            WebFactory.driver.Value = driver;
        }

        public async Task CaptureScreenshot(string testName)
        {
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)WebFactory.driver.Value).GetScreenshot();
                string timestamp = DateTime.Now.ToString("dd_MM_yyyy_HHmmss");
                string filterTestName = Regex.Replace(testName, @"[<>:""/\\|?*]", "_");
                var parentDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
                var screenshotDir = Path.Combine(parentDir, "Error_Screenshots");

                if (!Directory.Exists(screenshotDir))
                {
                    Directory.CreateDirectory(screenshotDir);
                }

                var filePath = Path.Combine(screenshotDir, $"{filterTestName}_{timestamp}.Png");
                screenshot.SaveAsFile(filePath);
                Console.WriteLine($"Screenshot saved at: {filePath}");
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
