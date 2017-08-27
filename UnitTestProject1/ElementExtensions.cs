using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    
    public static class ElementExtensions
    {

        /// <summary>
        ///     Gets the specified elements parent element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The parent element</returns>
        public static IWebElement GetParent(this IWebElement element)
        {
            return element.FindElement(By.XPath("./parent::*"));
        }

        /// <summary>
        ///     Gets the specified elements child element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The child element</returns>
        public static IWebElement GetChild(this IWebElement element)
        {
            return element.FindElement(By.XPath("./child::*"));
        }

        /// <summary>
        ///     Gets the preceding elements sibling.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static IWebElement GetPreviousSibling(this IWebElement element)
        {
            return element.FindElement(By.XPath("./preceding-sibling::*"));
        }

        /// <summary>
        ///     Gets the following elements sibling.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static IWebElement GetNextSibling(this IWebElement element)
        {
            return element.FindElement(By.XPath("./following-sibling::*"));
        }


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
