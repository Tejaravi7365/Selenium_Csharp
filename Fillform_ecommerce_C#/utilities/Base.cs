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

namespace Fillform_ecommerce_C.utilities
{
    public class Base
    {
        public IWebDriver driver;
        [SetUp]
        public void startbrowser()
        {
            String browsername = ConfigurationManager.AppSettings["browser"];
            //String browsername = "Edge";
            Initbrowser(browsername);

            driver.Manage().Window.Maximize();

            driver.Url = "https://rahulshettyacademy.com/angularpractice/";

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }

        public IWebDriver getdriver()
        {
            return driver;
        }
        public void Initbrowser(String browsername)
        {
            switch (browsername)
            {
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    Console.WriteLine("The chrome driver opened successfully");
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    Console.WriteLine("The Edge driver opened successfully");
                    break;

                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    Console.WriteLine("The Firefox driver opened successfully");
                    break;
            }
        }

        public static JsonReader getDataReader()
        {
            return new JsonReader();
        }

        [TearDown]
        public void stopbrowser()
        {
            driver.Close();
        }
    }

    
}
