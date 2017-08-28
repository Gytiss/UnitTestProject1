using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Drawing;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System.Globalization;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace Factory
{
    class MyClass
    {
        
        
        public class LocalDriver : IDriverContext
        {
            public IWebDriver GetDriver(string browserName, IWebDriver driver)
            {
                if (browserName.Equals("Chrome"))
                {
                    var options = new ChromeOptions();
                    options.AddArguments("disable-infobars");
                    options.AddArgument("--disable-notifications");
                    driver = new ChromeDriver(options);
                    
                }

                if (browserName.Equals("Firefox"))
                {
                    driver = new FirefoxDriver();
                }

                if (browserName.Equals("Edge"))
                {
                    driver = new EdgeDriver();
                }

                if (browserName.Equals("Explorer"))
                {
                    driver = new InternetExplorerDriver();
                }

                if (browserName.Equals("Phantom"))
                {
                    driver = new PhantomJSDriver();
                }

                driver.Manage().Window.Maximize();
                //driver.Manage().Window.Size = new Size(1300, 850);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                Console.WriteLine("Page opened: " + driver.Url);
                TestContext.Progress.WriteLine("Test running: " + TestContext.CurrentContext.Test.Name);

                return driver;
            }


        }

       

        private class RemoteDriver : IDriverContext
        {
            IWebDriver IDriverContext.GetDriver(string browserName, IWebDriver driver)
            {
                if (browserName.Equals("Chrome"))
                {
                    var uri = "uri_to_your_grid_hub";
                    var capabilities = new ChromeOptions().ToCapabilities();
                    var commandTimeout = TimeSpan.FromMinutes(5);
                    driver = new RemoteWebDriver(new Uri(uri), capabilities, commandTimeout);
                }

                if (browserName.Equals("Firefox"))
                {
                    driver = new FirefoxDriver();
                }

                if (browserName.Equals("Edge"))
                {
                    driver = new EdgeDriver();
                }

                if (browserName.Equals("Phantom"))
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


}
