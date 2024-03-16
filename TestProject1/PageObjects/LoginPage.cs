using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver= driver;
            PageFactory.InitElements(driver, this);
        }
        //driver.FindElement(By.XPath("//input[@id='terms']")).Click();
        //driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();


        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Name, Using ="password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//input[@id='terms']")]
        private IWebElement CheckBox;

        [FindsBy(How = How.CssSelector, Using = "input[value='Sign In']")]
        private IWebElement signInbutton;

        public IWebElement getUserName()
        {
            return username;
        }
        public IWebElement getPassword() 
        { 
            return password;
        }

        public IWebElement getCheckBox()
        {
            return CheckBox;
        }

        public IWebElement getsignIn()
        {
            return signInbutton;
        }

        public ProductsPage validlogin(string user,string pwd)
        {
            username.SendKeys(user);
            password.SendKeys(pwd);
            CheckBox.Click();
            signInbutton.Click();
            return new ProductsPage(driver);
            
        }
    }
}
