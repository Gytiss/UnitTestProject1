using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using UnitTestProject1.Elements;
using UnitTestProject1.PageObjects;
using OpenQA.Selenium.Support.Extensions;

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
            driver.TakeScreenshot();
            var search = driver.FindElement(By.Name("q"));
            search.Click();
            Console.WriteLine("Login to Google succeeded");
        }


        [Test]      
        public void Test2()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
            //IMyElement ez = new MyElement()
            Page2 page2 = new Page2(driver);
            page2.FindSmoth.Click();



            //driver.GetElement<IMyCheckBox>(By.XPath(".//*[@id='checkboxes']/input[2]")).UnCheck();
            //Thread.Sleep(3000);
            //driver.Navigate().GoToUrl("http://google.com");
            //driver.GetElement(By.Name("q")).SendKeys("terminator2");
            ////var test = driver.GetElement<IMyButton>(By.Name("btnK"), "testsd");
            ////test.Click();
            //driver.GetElement<IMyButton>(By.ClassName("lsb")).Click();
            //driver.GetElement(By.XPath("//a[contains(.,'Terminator 2: Judgment Day (1991) - IMDb')]")).Click();
            //driver.GetElement(By.XPath("//input[@name='q']")).SendKeys("terminator");
            //driver.GetElement(By.XPath("//button[@class='primary btn']")).Click();
            //driver.GetElement(By.XPath("//a[contains(.,'The Terminator')]")).Click();
            //driver.GetElement(By.XPath("//span[contains(.,'James Cameron')]")).Click();
            
            //driver.GetElement(By.Id("home_img")).Click();
            //driver.GetElement(By.Id("home_img")).Click();
            //driver.GetElement(By.Name("q")).SendKeys("terminator2");
            //driver.GetElement(By.Id("navbar-submit-button")).Click();
           
        }
    }




}







