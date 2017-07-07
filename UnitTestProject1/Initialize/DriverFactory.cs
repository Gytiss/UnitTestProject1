using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Drawing;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Firefox;

namespace UnitTestProject1
{
    public class LocalDriver : IDriverContext
    {
        public IWebDriver GetDriver(string browserName, IWebDriver driver)
        {
            if (browserName.Equals("chrome"))
            {
                var options = new ChromeOptions();
                options.AddArguments("disable-infobars");
                options.AddArgument("--disable-notifications");
                driver = new ChromeDriver(options);
            }

            if (browserName.Equals("firefox"))
            {
                driver = new FirefoxDriver();
            }

            if (browserName.Equals("phantom"))
            {
                driver = new PhantomJSDriver();
            }

            driver.Manage().Window.Size = new Size(1300, 850);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Console.WriteLine("Page opened: " + driver.Url);
            TestContext.Progress.WriteLine("Test running: " + TestContext.CurrentContext.Test.Name);

            return driver;
        }
    }

    public class RemoteDriver : IDriverContext
    {
        public IWebDriver GetDriver(string browserName, IWebDriver driver)
        {
            if (browserName.Equals("chrome"))
            {
                var options = new ChromeOptions();
                options.AddArguments("disable-infobars");
                options.AddArgument("--disable-notifications");
                driver = new ChromeDriver(options);
            }

            if (browserName.Equals("firefox"))
            {
                driver = new FirefoxDriver();
            }

            if (browserName.Equals("phantom"))
            {
                driver = new PhantomJSDriver();
            }
            return driver;
        }
    }

    public class LocalRemoteFactory
    {
        public virtual IDriverContext DriverGateway(string Type)
        {
            IDriverContext gateway = null;

            switch (Type)
            {
                case "Grid":
                    gateway = new RemoteDriver();
                    break;
                case "Local":
                    gateway = new LocalDriver();                                  
                    break;
            }

            return gateway;
        }
    }

}
