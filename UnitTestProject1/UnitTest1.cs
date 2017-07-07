using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace UnitTestProject1
{

    [TestFixture]
    public class TestClass : Hooks
    {
        [Test]
        public void Test(
        [ValueSource(typeof(Hooks), "BrowserToRun")]string browserName)
        {
            //Initialize(browserName);
            driver.Navigate().GoToUrl("http://google.com");
            driver.FindElement(By.Name("q"));
            Console.WriteLine("Login to Google succeeded");
        }


        [Test]      
        public void Test2(
       [ValueSource(typeof(Hooks), "BrowserToRun")]string browserName)
        {
            //Initialize(browserName);
            driver.Navigate().GoToUrl("http://google.com");
            driver.FindElement(By.Name("q"));
            Console.WriteLine("Login to Google succeeded");
        }
    }




}







