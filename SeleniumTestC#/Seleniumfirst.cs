using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTestC_
{
    internal class Seleniumfirst
    {
        IWebDriver driver;
        [SetUp]
        public void setupbrowser()
        {
            //webdriver and browser initialization
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            TestContext.Progress.WriteLine("Successfully opened chrome browser");
        }

        [Test]
        public void Test()
        {
            driver.Url = "https://rahulshettyacademy.com/#/index";
            TestContext.Progress.WriteLine("Sucessfully opened the Rahul shetty website");
        }

        [TearDown] 
        public void tearDownbrowser() 
        {
            driver.Close();
            TestContext.Progress.WriteLine("Successfully closed the driver");
        }
    }
}
