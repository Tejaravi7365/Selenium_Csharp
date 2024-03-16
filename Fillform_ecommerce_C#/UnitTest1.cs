using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using static System.Net.Mime.MediaTypeNames;

namespace Fillform_ecommerce_C_
{
    public class E2ETest
    {
        public IWebDriver driver;
        String[] expectedProducts = { "iphone X", "Blackberry" };
        String[] actualProducts = new string[2];
        [SetUp]
        public void Startbrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Url = "https://rahulshettyacademy.com/angularpractice/";

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        [Test]
        public void FormSubmission()
        {

            driver.FindElement(By.Name("name")).SendKeys("Ravi Teja");
            driver.FindElement(By.XPath("//input [@name='email']")).SendKeys("ravitejap976@gmail.com");
            driver.FindElement(By.Id("exampleInputPassword1")).SendKeys("Ravi@12");
            driver.FindElement(By.CssSelector("input[type ='checkbox']")).Click();

            IWebElement dropdown = driver.FindElement(By.XPath("//select [@id='exampleFormControlSelect1']"));

            SelectElement S = new SelectElement(dropdown);
            S.SelectByText("Female");

            IList <IWebElement> rados = driver.FindElements(By.CssSelector("input[type='radio']"));

            foreach (IWebElement rad in rados)
            {
                if (rad.GetAttribute("value").Equals("option1"))
                {
                    rad.Click();
                }
            }
            driver.FindElement(By.CssSelector("input[value='Submit']")).Click();

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".alert-success")));

            String confirText = driver.FindElement(By.CssSelector(".alert-success")).Text;

            StringAssert.Contains("Success", confirText);

            Console.WriteLine(confirText);
          
        }

        [Test]
        public void ClicktoOpenShopTab() 
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Shop")));

            driver.FindElement(By.LinkText("Shop")).Click();

            Console.WriteLine("Successfully clicked Shop tab");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
            
            SelectionProducts();
        }

          
        public void SelectionProducts()
        {
            
            IList <IWebElement> products = driver.FindElements(By.TagName("app-card"));

            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
                Console.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
            }

            driver.FindElement(By.ClassName("btn-primary")).Click();

            WebDriverWait wait1 = new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("btn-success")));

            driver.FindElement(By.ClassName("btn-success")).Click();

            //dyanamic dropdown 
      
            driver.FindElement(By.Id("country")).SendKeys("fin");

            IList<IWebElement> Options = driver.FindElements(By.CssSelector("app-checkout[class='row'] ul"));
            
            foreach (IWebElement option in Options)
            {
                if (option.Text.Equals("Finland"))
                {
                    option.Click();
                }
             
            }
            TestContext.Progress.WriteLine(driver.FindElement(By.Id("country")).GetAttribute("value"));
            driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            driver.FindElement(By.CssSelector("input[value='Purchase']")).Click();
            String S = driver.FindElement(By.ClassName("alert-success")).Text;

            StringAssert.Contains("Success", S);
            TestContext.Progress.WriteLine(S);

            Console.WriteLine("Successfully Placed order using C#");
        }

        
        [TearDown]
        public void Browserclose()
        {
            driver.Close();
        }
    }
}