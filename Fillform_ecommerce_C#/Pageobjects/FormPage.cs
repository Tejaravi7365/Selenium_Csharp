using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.DevTools.V120.Database;
using System.Security.Cryptography.X509Certificates;

namespace Fillform_ecommerce_C.Pageobjects
{
    public class FormPage
    {
        private IWebDriver driver;
        public FormPage(IWebDriver driver) 

        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //driver.FindElement(By.Name("name")).SendKeys("Ravi Teja");
        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement name;
        //driver.FindElement(By.XPath("//input [@name='email']")).SendKeys("ravitejap976@gmail.com");
        [FindsBy(How = How.XPath, Using = "//input [@name='email']")]
        private IWebElement email;
        //driver.FindElement(By.Id("exampleInputPassword1")).SendKeys("Ravi@12");
        [FindsBy(How = How.Id, Using = "exampleInputPassword1")]
        private IWebElement password;
        //driver.FindElement(By.CssSelector("input[type ='checkbox']")).Click();
        [FindsBy(How = How.CssSelector, Using = "input[type ='checkbox']")]
        private IWebElement checkbox;

        //driver.FindElement(By.XPath("//select [@id='exampleFormControlSelect1']"))
        [FindsBy(How = How.XPath, Using = "//select [@id='exampleFormControlSelect1']")]
        private IWebElement dropdown;

        //driver.FindElements(By.CssSelector("input[type='radio']"))
        [FindsBy(How =How.CssSelector, Using = "input[type='radio']")]
        private IList <IWebElement> rados;

        //driver.FindElement(By.CssSelector("input[value='Submit']")).Click();
        [FindsBy(How = How.CssSelector, Using = "input[value='Submit']")]
        private IWebElement submitbutton;

        //driver.FindElement(By.CssSelector(".alert-success"))
        [FindsBy(How= How.CssSelector, Using = ".alert-success")]
        private IWebElement altermessage;

        public IWebElement getName()
        {
            return name;
        }

        public IWebElement getEmail()
        {
            return email;
        }
        
        public IWebElement getPassword()
        {
            return password;
        }

        public IWebElement getCheckbox()
        {
            return checkbox;
        }

        public IWebElement getDropdown()
        {
            return dropdown;
        }

        public IList <IWebElement> getRados()
        {
            return rados;
        }

        public IWebElement getSubmitbutton()
        {
            return submitbutton;
        }

        public IWebElement getMessage()
        {
            return altermessage;
        }
    }



}
