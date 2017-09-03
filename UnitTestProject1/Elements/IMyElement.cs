using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.Elements
{

    public interface IMyElement : IMySearch
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

    }

    public interface IMyCheckBox : IMySearch
    {
        /// <summary>
        /// Clicks this element
        /// </summary>
        void Click();

        void Check();
        void UnCheck();

    }

    //class MyClass: FindsByAttribute
    //{

    //}


    public class MyElement : IMyElement, IMyButton, IMyCheckBox
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

        public void Check()
        {
            if (!_element.Selected)
            {
                _element.Click();
            }
        }

        public void UnCheck()
        {
            if (_element.Selected)
            {
                _element.Click();
            }
        }
    }

    public interface IOther
    {
        string GetAttribute(string attributeName);

        string GetCssValue(string propertyName);

        string Text { get; }
        bool Enabled { get; }
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
