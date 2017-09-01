using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace UnitTestProject1.Elements
{

    public interface IMyElement: IMySearch
    {
        /// <summary>
        /// Clicks this element
        /// </summary>
        void Click();

        void SendKeys(string text);

    }

    public interface IMySearch
    {

        IOther Other { get; }

        IMyElement GetElement(By by);
    }

    public interface IMyButton : IMySearch
    {
        /// <summary>
        /// Clicks this element
        /// </summary>
        void Click();

        //IOther Other { get; }

        //IMyElement GetElement(By by);
    }

    public interface ICheckBox : IMySearch
    {
        /// <summary>
        /// Clicks this element
        /// </summary>
        void Click();

        //IOther Other { get; }
        //
        //IMyElement GetElement(By by);
    }


    public class MyElement : IMyElement, IMyButton
    {
        private IWebElement _element;

        public IOther Other => new Other(_element);

        public IWebElement WebElement => _element;

        private ISearchContext _search;


        public MyElement(IWebElement element, By by, ISearchContext search)
        {
            _search = search;
            _element = element;
        }

        public void Click()
        {
            _element.Click();
        }


        public IMyElement GetElement(By by)
        {
            return _search.FindElement(by) as IMyElement;
        }

        public void SendKeys(string text)
        {
            _element.SendKeys(text);
        }
    }

    public interface IOther
    {
        string GetAttribute(string attributeName);

        string GetCssValue(string propertyName);

        string Text { get; }
        //
        // Summary:
        //     Gets a value indicating whether or not this element is enabled.
        //
        // Exceptions:
        //   T:OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        //
        // Remarks:
        //     The OpenQA.Selenium.IWebElement.Enabled property will generally return true for
        //     everything except explicitly disabled input elements.
        bool Enabled { get; }
        //
        // Summary:
        //     Gets a value indicating whether or not this element is selected.
        //
        // Exceptions:
        //   T:OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        //
        // Remarks:
        //     This operation only applies to input elements such as checkboxes, options in
        //     a select element and radio buttons.
        bool Selected { get; }
    }


    public class Other : IOther
    {
        IWebElement _myElement;
        public Other(IWebElement myElement)
        {
            _myElement = myElement;
        }

        public string Text => _myElement.Text;

        public bool Enabled => _myElement.Enabled;

        public bool Selected => _myElement.Selected;

        public string GetAttribute(string attributeName)
        {
            return _myElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return _myElement.GetCssValue(propertyName);
        }

    }
}
