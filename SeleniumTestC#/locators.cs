using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTestC_
{
    public class locators
    {
        IWebDriver driver;
        [SetUp]
        public void setupbrowser()
        {
            //webdriver and browser initialization
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

            TestContext.Progress.WriteLine("Successfully opened chrome browser");
        }

        [Test]
        public void Locationidentifiers()
        {
            driver.FindElement(By.Id("username")).SendKeys("rahulshetty");
            driver.FindElement(By.CssSelector("input[id='password']")).SendKeys("12345");
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();

            Thread.Sleep(3000);
            driver.FindElements(By.)

            TestContext.Progress.WriteLine("Webpage opened successfully");
        }

    }
}
