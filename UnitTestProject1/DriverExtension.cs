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
using UnitTestProject1.Elements;

namespace UnitTestProject1
{
    
    public static class DriverExtension
    {
        
        public static IMyElement GetElement(this ISearchContext element, By by)
        {
            var test = element.GetElement<MyElement>(by);
            return test;
        }

        public static T GetElement<T>(this ISearchContext searchContext, By by)
            where T : class
        {
            IWebElement webElemement = searchContext.FindElement(by);
            //ISearchContext search = searchContext;
            return webElemement.As2<T>(by, searchContext);
        }

        /// <summary>
        /// Converts generic IWebElement into specified web element (Checkbox, Table, etc.) .
        /// </summary>
        /// <typeparam name="T">Specified web element class</typeparam>
        /// <param name="webElement">Generic IWebElement.</param>
        /// <returns>
        /// Specified web element (Checkbox, Table, etc.)
        /// </returns>
        /// <exception cref="System.ArgumentNullException">When constructor is null.</exception>
        private static T As<T>(this IWebElement webElement)
            where T : class
        {
            var constructor = typeof(T).GetConstructor(new[] { typeof(IWebElement)});

            if (constructor != null)
            {
                return constructor.Invoke(new object[] { webElement}) as T;
            }

            throw new ArgumentNullException(string.Format(CultureInfo.CurrentCulture, "Constructor for type {0} is null.", typeof(T)));
        }


        /// <summary>
        /// Converts generic IWebElement into specified web element (Checkbox, Table, etc.) .
        /// </summary>
        /// <typeparam name="T">Specified web element class</typeparam>
        /// <param name="webElement">Generic IWebElement.</param>
        /// <returns>
        /// Specified web element (Checkbox, Table, etc.)
        /// </returns>
        /// <exception cref="System.ArgumentNullException">When constructor is null.</exception>
        private static T As2<T>(this IWebElement webElement, By by, ISearchContext search)
            where T : class
        {
            var constructor = typeof(T).GetConstructor(new[] { typeof(IWebElement), typeof(By), typeof(ISearchContext)});

            if (constructor != null)
            {
                return constructor.Invoke(new object[] { webElement, by, search }) as T;
            }

            throw new ArgumentNullException(string.Format(CultureInfo.CurrentCulture, "Constructor for type {0} is null.", typeof(T)));
        }

    }
}
