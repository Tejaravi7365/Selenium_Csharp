using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1.Utilities
{
    public class Base
    {
        public IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            String browsername = ConfigurationManager.AppSettings["browser"];

            // Initialzing webdrivermanager with chrome driver 
            
            InitBrowser(browsername);

            //To maximize browser window full page
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

            //Applying implict wait for browser
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);

            Console.WriteLine(driver.Title);
        }

        public IWebDriver getdriver()
        {
            return driver;
        }
        //Initializing browser driver configurations different browsers
        public void InitBrowser(String browsername)
        {
            switch (browsername)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    Console.WriteLine("The Firefox browser opened");
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    Console.WriteLine("The Edge browser opened");
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    Console.WriteLine("The Chrome browser opened");
                    break;


            }
        }
       
        [TearDown]
        public void AfterTest()
        {
           // driver.Quit();
            Console.WriteLine("The browser closed");
        }
    }
}
