using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Initialize
{
    class HelperMethods : Hooks
    {

        public HelperMethods(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        string dir = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\CookieJson\\";

        public void PopulateGoogleCookieJsonGoToSyncGenePage(string fileName)
        {
            driver.Navigate().GoToUrl("https://accounts.google.com");
            JArray jArray = JArray.Parse(File.ReadAllText(dir + @"\" + fileName));
            driver.Manage().Cookies.DeleteAllCookies();
            foreach (JObject item in jArray)
            {
                string secure = item.GetValue("Secure").ToString();
                string IsHttpOnly = item.GetValue("IsHttpOnly").ToString();
                string name = item.GetValue("Name").ToString();
                string value = item.GetValue("Value").ToString();
                string domain = item.GetValue("Domain").ToString();
                string path = item.GetValue("Path").ToString();
                string expiry = item.GetValue("Expiry").ToString();

                try
                {
                    Cookie c1 = new Cookie(name, value, path, Convert.ToDateTime(expiry));
                    driver.Manage().Cookies.AddCookie(c1);
                }
                catch (Exception)
                {
                    Cookie c1 = new Cookie(name, value, path);
                    driver.Manage().Cookies.AddCookie(c1);

                }

            }

            driver.Navigate().GoToUrl("https://app.syncgene.com/");
        }


        public void WriteCookieToFileJson(string fileName)
        {
            ReadOnlyCollection<Cookie> sd = driver.Manage().Cookies.AllCookies;
            var json = JsonConvert.SerializeObject(sd);
            JArray v = JArray.Parse(json);
            File.WriteAllText(dir + @"\" + fileName, json);
        }

        public void WaitUntilDocReady(int TimeInSeconds)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
