using Factory;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using static Factory.MyClass;

namespace UnitTestProject1
{
    public class Hooks: Config
    {
        private IDriverContext gateway = null;
        public IWebDriver driver = null;



        private void Initialize(string browserName, string environment)
        {
            LocalRemoteFactory factory = new LocalRemoteFactory();
            this.gateway = factory.DriverGateway(environment);
            driver = this.gateway.GetDriver(browserName, driver);
        }

        ////[SetUp]
        //public void Initialize()
        //{
        //    var browserName = BrowserToRun().FirstOrDefault();
        //    Initialize(browserName, "Local");
        //}

        public Hooks() 
        {
            
            var browserName = BrowserToRun().FirstOrDefault();
            var environment = Environment().FirstOrDefault();
            Initialize(browserName, environment);
        }

        public Hooks(string browserName, string environment)
        {
            Initialize(browserName, environment);
        }


        [TearDown]
        public virtual void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Passed))
            {
                Console.WriteLine("Test Passed");
            }

            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                try
                {
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH;mm;ss");
                    string methodName = TestContext.CurrentContext.Test.MethodName;
                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    string screenShotDir = AppDomain.CurrentDomain.BaseDirectory + "TestData\\";
                    string screenshotLocation = screenShotDir + methodName + " " + timestamp + @"s Screenshot.jpg";
                    TestContext.Progress.WriteLine("Screenshot saving at: " + screenshotLocation);
                    screenshot.SaveAsFile(screenshotLocation, ScreenshotImageFormat.Jpeg);
                    Console.WriteLine("Screenshot saved at: " + screenshotLocation);
                    TestContext.Progress.WriteLine("Screenshot saved at: " + screenshotLocation);
                }

                catch (Exception)
                {
                    driver.Quit();
                }

                if (TestContext.CurrentContext.Result.Outcome.Label == "Error")
                {
                    Console.WriteLine("Test is in Error");
                    Console.WriteLine(TestContext.CurrentContext.Result.Message);
                }

                else
                    Console.WriteLine("Test Failed");

            }

            driver.Quit();

        }

    }
}
