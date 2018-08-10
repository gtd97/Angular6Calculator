using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Configuration;
using OpenQA.Selenium.Support.UI;

namespace TestAngularCalculator
{
    [TestClass]
    public class E2ETest
    {
        private static IWebDriver Driver;
        //private static readonly String base_url = ConfigurationManager.AppSettings["baseUrl"];
        private static WebDriverWait wait;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://localhost:4200/calculadora");
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
        }

        [AssemblyCleanup]
        public static void AssemblyTearDown()
        {
            Driver.Close();
            Driver.Quit();
        }


        [TestMethod]
        public void SeleniumTestUsingCSharp()
        {
            var result = "";

            // Title
            Func<IWebDriver, bool> waitForTitle = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                result = Driver.FindElement(By.Id("title")).Text;
                
                return true;
            });
            wait.Until(waitForTitle);
            Assert.AreEqual(result, "Calculadora");
            


            // Sum
            Driver.FindElement(By.Id("field1")).Clear();
            Driver.FindElement(By.Id("field2")).Clear();

            Driver.FindElement(By.Id("field1")).SendKeys("5");
            Driver.FindElement(By.Id("field2")).SendKeys("3");
            Driver.FindElement(By.Id("suma")).Click();
            
            Func<IWebDriver, bool> waitForSum = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                result = Driver.FindElement(By.Id("result")).Text;
                return true;
            });
            wait.Until(waitForSum);
            Assert.AreEqual(result, "8");
            


            // Substraction 
            Driver.FindElement(By.Id("field1")).Clear();
            Driver.FindElement(By.Id("field2")).Clear();

            Driver.FindElement(By.Id("field1")).SendKeys("5");
            Driver.FindElement(By.Id("field2")).SendKeys("3");
            Driver.FindElement(By.Id("substraction")).Click();
            
            Func<IWebDriver, bool> waitForSubstract = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                result = Driver.FindElement(By.Id("result")).Text;
                return true;
            });
            wait.Until(waitForSum);
            Assert.AreEqual(result, "2");
            

            // Multiply 
            Driver.FindElement(By.Id("field1")).Clear();
            Driver.FindElement(By.Id("field2")).Clear();

            Driver.FindElement(By.Id("field1")).SendKeys("5");
            Driver.FindElement(By.Id("field2")).SendKeys("3");
            Driver.FindElement(By.Id("multiply")).Click();
            
            Func<IWebDriver, bool> waitForMultiply = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                result = Driver.FindElement(By.Id("result")).Text;
                return true;
            });
            wait.Until(waitForMultiply);
            Assert.AreEqual(result, "15");
            

            // Divide 
            Driver.FindElement(By.Id("field1")).Clear();
            Driver.FindElement(By.Id("field2")).Clear();

            Driver.FindElement(By.Id("field1")).SendKeys("4");
            Driver.FindElement(By.Id("field2")).SendKeys("2");
            Driver.FindElement(By.Id("divide")).Click();
            
            Func<IWebDriver, bool> waitForDivide = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                result = Driver.FindElement(By.Id("result")).Text;
                return true;
            });
            wait.Until(waitForDivide);
            Assert.AreEqual(result, "2");
        }

    }
}
