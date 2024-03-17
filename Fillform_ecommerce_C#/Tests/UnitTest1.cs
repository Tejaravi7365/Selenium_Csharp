using Fillform_ecommerce_C.Pageobjects;
using Fillform_ecommerce_C.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using static System.Net.Mime.MediaTypeNames;

namespace Fillform_ecommerce_C.Tests
{
    public class E2ETest : Base
    {

        string[] expectedProducts = { "iphone X", "Blackberry" };
        string[] actualProducts = new string[2];

        [Test, TestCaseSource("Addtestdataconfig")]
        public void Test_FormSubmission(string name, string email, string password)
        {

            FormPage formpage = new FormPage(getdriver());
            formpage.getName().SendKeys(name);
            formpage.getEmail().SendKeys(email);
            formpage.getPassword().SendKeys(password);
            formpage.getCheckbox().Click();
            IWebElement drop = formpage.getDropdown();
            SelectElement S = new SelectElement(drop);
            S.SelectByText("Female");

            IList<IWebElement> rads = formpage.getRados();

            foreach (IWebElement rad in rads)
            {
                if (rad.GetAttribute("value").Equals("option1"))
                {
                    rad.Click();
                }
            }
            formpage.getSubmitbutton().Click();

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".alert-success")));

            string confirText = formpage.getMessage().Text;

            StringAssert.Contains("Success", confirText);

            Console.WriteLine(confirText);
        }

        public static IEnumerable<TestCaseData> Addtestdataconfig()
        {
            yield return new TestCaseData(getDataReader().ReadsData("name"), getDataReader().ReadsData("email"), getDataReader().ReadsData("password"));
            Console.WriteLine("Json Dataset passed to testcase");
            yield return new TestCaseData(getDataReader().ReadsData("name1"), getDataReader().ReadsData("email1"), getDataReader().ReadsData("password"));
            Console.WriteLine("Json Dataset2 passed to testcase");
            yield return new TestCaseData("Teja", "ravitejap6@gmail.com", "Ravi@1");
            Console.WriteLine("String Dataset passed to testcase");
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

            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
                Console.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
            }

            driver.FindElement(By.ClassName("btn-primary")).Click();

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
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
            string S = driver.FindElement(By.ClassName("alert-success")).Text;

            StringAssert.Contains("Success", S);
            TestContext.Progress.WriteLine(S);

            Console.WriteLine("Successfully Placed order using C#");
        }
    }
}