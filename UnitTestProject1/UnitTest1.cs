using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace UnitTestProject1
{

    [TestFixture]
    public class TestClass : Hooks
    {

        [Test]
        [Order(1)]
        public void Test(
        [ValueSource(typeof(Hooks), "BrowserToRun")]string browserName)
        {
            Initialize(browserName);
            driver.Navigate().GoToUrl("http://google.com");
            driver.FindElement(By.Name("q"));
            Console.WriteLine("Login to Google succeeded");
        }
    }


}







