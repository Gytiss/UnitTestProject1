using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace UnitTestProject1
{

    [TestFixture]
    public class TestClass: Hooks
    {
        
        [Test]
        public void Test()
        {
            Thread.Sleep(2000);
            //LocalDriver test = new LocalDriver();
            driver.Navigate().GoToUrl("http://google.com");
            var search = driver.FindElement(By.Name("q"));
            search.Click();
            Console.WriteLine("Login to Google succeeded");
        }


        [Test]      
        public void Test2()
        {            
            driver.Navigate().GoToUrl("http://google.com");
            var myElement = driver.GetElement(By.XPath("//a[contains(.,'Gmail')]"));
            string text = myElement.Other.Text;
            Console.WriteLine(text);
        }
    }




}







