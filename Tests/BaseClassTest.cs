using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SauseLabPomProject.Credentials;
using SauseLabPomProject.Drivers;
using SauseLabPomProject.Pages.ScreenshotsPage;
using SauseLabPomProject.Pages;
using SauseLabPomProject.Util;
using log4net;
using System.Reflection;
using log4net.Config;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace SauseLabPomProject.Tests
{
    public class BaseClassTest
    {
        protected CredentialProvider _credentialProvider;
        protected PageFactory _pageFactory;
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod()!.DeclaringType);
        private static ExtentReports _extentReports;
        private static ExtentSparkReporter _sparkReporter;
        private ExtentTest _extentTest;

        static BaseClassTest()
        {
            var log4NetConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Credentials", "Log4net.config");
            var logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Logs");

            if (!Directory.Exists(logFilePath))
            {
                Directory.CreateDirectory(logFilePath);
            }

            if (File.Exists(log4NetConfig))
            {
                XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetConfig));
            }

            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Reports", $"ExtentReport_{timestamp}.html");
            var reportDir = Path.GetDirectoryName(reportPath)!;

            if (!Directory.Exists(reportDir))
            {
                Directory.CreateDirectory(reportDir);
            }

            _sparkReporter = new ExtentSparkReporter(reportPath);
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_sparkReporter);
        }

        [SetUp]
        public async Task SetUp()
        {
            WebFactory.driver.Value = WebFactory.CreateDriver("chrome");
            _credentialProvider = new CredentialProvider();
            _pageFactory = new PageFactory(WebFactory.driver.Value);
            var baseUrl = _credentialProvider.GetBaseUrl();
            WebFactory.driver.Value.Navigate().GoToUrl(baseUrl);
            _extentTest = _extentReports.CreateTest(TestContext.CurrentContext.Test.Name);
            await Task.CompletedTask;
        }

        protected T GetPage<T>() where T : BaseClass
        {
            return _pageFactory.CreatePage<T>();
        }

        protected async Task Login(string userType)
        {
            var (username, password) = _credentialProvider.GetCredential(userType);
            var loginPage = GetPage<LoginPage>();
            await loginPage.UserLogin(username, password);
        }

        [TearDown]
        public async Task CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var takeScreenshot = new TakeScreenShot(WebFactory.driver.Value);
                await takeScreenshot.CaptureScreenshot(TestContext.CurrentContext.Test.Name);

                _log.Error($"Test Failed: {TestContext.CurrentContext.Test.FullName}");
                _log.Error($"Error Message: {TestContext.CurrentContext.Result.Message}");

                _extentTest.Fail($"Test Failed: {TestContext.CurrentContext.Test.FullName}");
                _extentTest.Fail($"Error Message: {TestContext.CurrentContext.Result.Message}");
            }
            else
            {
                _extentTest.Pass("Test Passed");
                _log.Info($"Test Passed: {TestContext.CurrentContext.Test.FullName}");
            }

            WebFactory.driver.Value?.Quit();
            WebFactory.driver.Value = null;
            await Task.CompletedTask;
        }

        [OneTimeTearDown]
        public static void AfterTestRun()
        {
            _extentReports.Flush();
        }
    }
}
