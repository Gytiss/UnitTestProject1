﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    public class MyFactory
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PageFactory"/> class.
        /// Private constructor prevents a default instance from being created.
        /// </summary>
        private MyFactory()
        {
        }

        /// <summary>
        /// Initializes the elements in the Page Object with the given type.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the Page Object class.</typeparam>
        /// <param name="driver">The <see cref="IWebDriver"/> instance used to populate the page.</param>
        /// <returns>An instance of the Page Object class with the elements initialized.</returns>
        /// <remarks>
        /// The class used in the <typeparamref name="T"/> argument must have a public constructor
        /// that takes a single argument of type <see cref="IWebDriver"/>. This helps to enforce
        /// best practices of the Page Object pattern, and encapsulates the driver into the Page
        /// Object so that it can have no external WebDriver dependencies.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// thrown if no constructor to the class can be found with a single IWebDriver argument
        /// <para>-or-</para>
        /// if a field or property decorated with the <see cref="FindsByAttribute"/> is not of type
        /// <see cref="IWebElement"/> or IList{IWebElement}.
        /// </exception>
        public static T InitElements<T>(IWebDriver driver)
        {
            return InitElements<T>(new DefaultElementLocator(driver));
        }

        /// <summary>
        /// Initializes the elements in the Page Object with the given type.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the Page Object class.</typeparam>
        /// <param name="locator">The <see cref="IElementLocator"/> implementation that
        /// determines how elements are located.</param>
        /// <returns>An instance of the Page Object class with the elements initialized.</returns>
        /// <remarks>
        /// The class used in the <typeparamref name="T"/> argument must have a public constructor
        /// that takes a single argument of type <see cref="IWebDriver"/>. This helps to enforce
        /// best practices of the Page Object pattern, and encapsulates the driver into the Page
        /// Object so that it can have no external WebDriver dependencies.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// thrown if no constructor to the class can be found with a single IWebDriver argument
        /// <para>-or-</para>
        /// if a field or property decorated with the <see cref="FindsByAttribute"/> is not of type
        /// <see cref="IWebElement"/> or IList{IWebElement}.
        /// </exception>
        public static T InitElements<T>(IElementLocator locator)
        {
            T page = default(T);
            Type pageClassType = typeof(T);
            ConstructorInfo ctor = pageClassType.GetConstructor(new Type[] { typeof(IWebDriver) });
            if (ctor == null)
            {
                throw new ArgumentException("No constructor for the specified class containing a single argument of type IWebDriver can be found");
            }

            if (locator == null)
            {
                throw new ArgumentNullException("locator", "locator cannot be null");
            }

            IWebDriver driver = locator.SearchContext as IWebDriver;
            if (driver == null)
            {
                throw new ArgumentException("The search context of the element locator must implement IWebDriver", "locator");
            }

            page = (T)ctor.Invoke(new object[] { locator.SearchContext as IWebDriver });
            InitElements(page, locator);
            return page;
        }

        /// <summary>
        /// Initializes the elements in the Page Object.
        /// </summary>
        /// <param name="driver">The driver used to find elements on the page.</param>
        /// <param name="page">The Page Object to be populated with elements.</param>
        /// <exception cref="ArgumentException">
        /// thrown if a field or property decorated with the <see cref="FindsByAttribute"/> is not of type
        /// <see cref="IWebElement"/> or IList{IWebElement}.
        /// </exception>
        public static void InitElements(ISearchContext driver, object page)
        {
            InitElements(page, new DefaultElementLocator(driver));
        }

        /// <summary>
        /// Initializes the elements in the Page Object.
        /// </summary>
        /// <param name="driver">The driver used to find elements on the page.</param>
        /// <param name="page">The Page Object to be populated with elements.</param>
        /// <param name="decorator">The <see cref="IPageObjectMemberDecorator"/> implementation that
        /// determines how Page Object members representing elements are discovered and populated.</param>
        /// <exception cref="ArgumentException">
        /// thrown if a field or property decorated with the <see cref="FindsByAttribute"/> is not of type
        /// <see cref="IWebElement"/> or IList{IWebElement}.
        /// </exception>
        public static void InitElements(ISearchContext driver, object page, IPageObjectMemberDecorator decorator)
        {
            InitElements(page, new DefaultElementLocator(driver), decorator);
        }

        /// <summary>
        /// Initializes the elements in the Page Object.
        /// </summary>
        /// <param name="page">The Page Object to be populated with elements.</param>
        /// <param name="locator">The <see cref="IElementLocator"/> implementation that
        /// determines how elements are located.</param>
        /// <exception cref="ArgumentException">
        /// thrown if a field or property decorated with the <see cref="FindsByAttribute"/> is not of type
        /// <see cref="IWebElement"/> or IList{IWebElement}.
        /// </exception>
        public static void InitElements(object page, IElementLocator locator)
        {
            InitElements(page, locator, new DefaultPageObjectMemberDecorator());
        }

        /// <summary>
        /// Initializes the elements in the Page Object.
        /// </summary>
        /// <param name="page">The Page Object to be populated with elements.</param>
        /// <param name="locator">The <see cref="IElementLocator"/> implementation that
        /// determines how elements are located.</param>
        /// <param name="decorator">The <see cref="IPageObjectMemberDecorator"/> implementation that
        /// determines how Page Object members representing elements are discovered and populated.</param>
        /// <exception cref="ArgumentException">
        /// thrown if a field or property decorated with the <see cref="FindsByAttribute"/> is not of type
        /// <see cref="IWebElement"/> or IList{IWebElement}.
        /// </exception>
        public static void InitElements(object page, IElementLocator locator, IPageObjectMemberDecorator decorator)
        {
            if (page == null)
            {
                throw new ArgumentNullException("page", "page cannot be null");
            }

            if (locator == null)
            {
                throw new ArgumentNullException("locator", "locator cannot be null");
            }

            if (decorator == null)
            {
                throw new ArgumentNullException("locator", "decorator cannot be null");
            }

            if (locator.SearchContext == null)
            {
                throw new ArgumentException("The SearchContext of the locator object cannot be null", "locator");
            }

            const BindingFlags PublicBindingOptions = BindingFlags.Instance | BindingFlags.Public;
            const BindingFlags NonPublicBindingOptions = BindingFlags.Instance | BindingFlags.NonPublic;

            // Get a list of all of the fields and properties (public and non-public [private, protected, etc.])
            // in the passed-in page object. Note that we walk the inheritance tree to get superclass members.
            var type = page.GetType();
            var members = new List<MemberInfo>();
            members.AddRange(type.GetFields(PublicBindingOptions));
            members.AddRange(type.GetProperties(PublicBindingOptions));
            while (type != null)
            {
                members.AddRange(type.GetFields(NonPublicBindingOptions));
                members.AddRange(type.GetProperties(NonPublicBindingOptions));
                type = type.BaseType;
            }

            foreach (var member in members)
            {
                // Examine each member, and if the decorator returns a non-null object,
                // set the value of that member to the decorated object.
                object decoratedValue = decorator.Decorate(member, locator);
                if (decoratedValue == null)
                {
                    continue;
                }

                var field = member as FieldInfo;
                var property = member as PropertyInfo;
                if (field != null)
                {
                    field.SetValue(page, decoratedValue);
                }
                else if (property != null)
                {
                    property.SetValue(page, decoratedValue, null);
                }
            }
        }
    }

}
