using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    
    public static class SeleniumExtension
    {
        //static Base x = new Base();
        //public static IWebDriver driver { get; set; }

        public static void EnterText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void Click_WaitForSpinner(this IWebElement element, IWebDriver driver)
        {

            element.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(37)).
                 Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".content-loader")));
        }

        public static void Click_IgnoreStaleElementException(this IWebElement element, IWebDriver driver)
        {

            WebDriverWait waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(37));
            waiter.Until(ExpectedConditions.ElementToBeClickable(element));
            waiter.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            element.Click();
        }

        //public static void Click_WaitForSpinner2(this IWebElement element)
        //{
        //    var driver = ((IWrapsDriver)element).WrappedDriver;
        //    element.Click();
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(35)).
        //         Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".content-loader")));
        //}



    }
}
