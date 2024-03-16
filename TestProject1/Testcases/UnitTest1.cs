using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V120.Console;
using TestProject1.PageObjects;
using TestProject1.Utilities;

namespace TestProject1.Testcases
{
    public class E2ETest : Base
    {

        [Test]
        public void Test1()
        {
            LoginPage loginPage = new LoginPage(getdriver());
            ProductsPage productsPage = loginPage.validlogin("rahulshettyacademy", "learning");
            productsPage.WaitforcheckoutPage();

            IList<IWebElement> products = productsPage.getCards();
            Console.WriteLine(products);
            Console.WriteLine("Test1: Executed scuessfully");
        }
    }
}