using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SauseLabPomProject.Credentials;
using SauseLabPomProject.Drivers;
using SauseLabPomProject.Pages.ScreenshotsPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SauseLabPomProject.Pages;
using SauseLabPomProject.Util;
using log4net;
using System.Reflection;
using log4net.Config;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;


namespace SauseLabPomProject.Tests
{
    public class BaseClassTest
    {
        //protected IWebDriver _driver;
        protected CredentialProvider _credentialProvider;
        protected PageFactory _pageFactory;
        private readonly ILog _log=LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static ExtentReports _extentReports;
        private static ExtentSparkReporter _sparkReporter;
        private ExtentTest _extentTest;


        static BaseClassTest()
        {
           
            var log4NetConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Credentials", "Log4net.config");
            var logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..", "..", "..", "Logs");

            if(!Directory.Exists(logFilePath))
            {
                Directory.CreateDirectory(logFilePath);
            }
            if (File.Exists(log4NetConfig))
            {
                XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetConfig));
                
            }
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Reports", $"ExtentReport_{timestamp}.html");
            var reportDir = Path.GetDirectoryName(reportPath);

            if (!Directory.Exists(reportDir))
            {
                Directory.CreateDirectory(reportDir);
            }

            _sparkReporter = new ExtentSparkReporter(reportPath);
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_sparkReporter);

        }




        [SetUp]
        public void SetUp()
        {

           
            WebFactory.driver.Value = WebFactory.CreateDriver("chrome");
            _credentialProvider = new CredentialProvider();
            _pageFactory=new PageFactory(WebFactory.driver.Value);
            var baseUrl = _credentialProvider.GetBaseUrl();
            WebFactory.driver.Value.Navigate().GoToUrl(baseUrl);
            _extentTest = _extentReports.CreateTest(TestContext.CurrentContext.Test.Name);



        }

        
        protected T GetPage<T>() where T: BaseClass
        {
            return _pageFactory.CreatePage<T>();    
        }


        protected void Login(string userType)
        {
            var(username,password)=_credentialProvider.GetCredential(userType);
            var loginPage=GetPage<LoginPage>();
            loginPage.UserLogin(username,password);
        }


        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {

                var _takeScreenshot = new TakeScreenShot(WebFactory.driver.Value);
                _takeScreenshot.CaptureScreenshot(TestContext.CurrentContext.Test.Name);


                _log.Error($"Test Failed: {TestContext.CurrentContext.Test.FullName}");
                _log.Error($"Test Failed: {TestContext.CurrentContext.Result.Message}");

                _extentTest.Fail($"Test Failed: {TestContext.CurrentContext.Test.FullName}");
                _extentTest.Fail($"Error Message: {TestContext.CurrentContext.Result.Message}");
               

            }
            else
            {
                _extentTest.Pass("Test Passed");
                _log.Info($"Test Passed: {TestContext.CurrentContext.Test.FullName}");
            }

            WebFactory.driver.Value?.Close();

        }

            [OneTimeTearDown]
            public static void AfterTestRun()
            {
                _extentReports.Flush();
               
            }

        
    }
}
