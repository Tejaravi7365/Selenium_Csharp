using AventStack.ExtentReports;
using Fillform_ecommerce_C.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.DevTools.V120.Page;
using NUnit.Framework.Internal.Execution;


namespace Fillform_ecommerce_C.utilities
{
    public class Base
    {
        public ExtentReports extent;
        public ExtentTest test;

        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        //report file 
        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmplReporter = new ExtentHtmlReporter(reportPath);

            extent = new ExtentReports();
            extent.AttachReporter(htmplReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("User Name", "Teja");

        }


        [SetUp]
        public void startbrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            String browsername = ConfigurationManager.AppSettings["browser"];
            //String browsername = "Edge";
            Initbrowser(browsername);

            driver.Value.Manage().Window.Maximize();

            driver.Value.Url = "https://rahulshettyacademy.com/angularpractice/";

            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }

        public IWebDriver getdriver()
        {
            return driver.Value;
        }
        public void Initbrowser(String browsername)
        {
            switch (browsername)
            {
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    Console.WriteLine("The chrome driver opened successfully");
                    break;

                case "Edge":
                    
                    driver.Value = new EdgeDriver();
                    Console.WriteLine("The Edge driver opened successfully");
                    break;

                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value= new FirefoxDriver();
                    Console.WriteLine("The Firefox driver opened successfully");
                    break;
            }
        }

        public static JsonReader getDataReader()
        {
            return new JsonReader();
        }

        public IWebDriver GetDriver()
        {
            return driver.Value;
        }

        [TearDown]
        public void stopbrowser()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;


            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            if(status == TestStatus.Failed)
            {
                test.Fail("Test Failed",captureScreenShot(driver.Value, fileName));
                test.Log(Status.Fail, "test failed with logtrac" + stackTrace);
            }
            else if(status == TestStatus.Passed)
            {
                test.Pass("Test Passed", captureScreenShot(driver.Value, fileName));
                test.Log(Status.Pass, "test passed with logtrac" + stackTrace);

            }

            extent.Flush();
            driver.Value.Close();
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver,String screenShotName)
        {
            ITakesScreenshot TS = (ITakesScreenshot)driver;
            var scrennShot = TS.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(scrennShot, screenShotName).Build();

        }
    }

    
}
