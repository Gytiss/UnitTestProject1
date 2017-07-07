using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;


namespace UnitTestProject1
{
    public class Hooks
    {
        IDriverContext gateway = null;
        public IWebDriver driver = null;
        
        //[SetUp]
        public void Initialize(string browserName)
        {           
            LocalRemoteFactory factory = new LocalRemoteFactory();
            this.gateway = factory.DriverGateway("Local");
            driver = this.gateway.GetDriver(browserName, driver);            
        }


        public static IEnumerable<String> BrowserToRun()
        {
            String browsers = ConfigurationManager.AppSettings["Browser"];

            yield return browsers;
           
        }

        public static IEnumerable<String> SyncGeneVersion()
        {
            String versions = ConfigurationManager.AppSettings["Version"];

            yield return versions;

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
