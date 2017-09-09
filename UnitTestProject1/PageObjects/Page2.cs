using OpenQA.Selenium;
using OpenQA.Selenium.Appium.PageObjects;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Elements;
using Yandex.HtmlElements.Elements;
using Yandex.HtmlElements.Loaders;

namespace UnitTestProject1.PageObjects
{
    public class Page2
    {

        //IWebDriver driver;
        
        public Page2(IWebDriver driver)
        {
            ///this.driver = driver;
            HtmlElementLoader.PopulatePageObject(this, driver);
            //DefaultElementLocator locator = new DefaultElementLocator(driver);
            //PageFactory.InitElements(driver, this, new AppiumPageObjectMemberDecorator());
            //MyFactory.InitElements(driver, this, );
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='checkboxes']/input[2]")]
        private IMyCheckBox ele;

        //[FindsBy(How = How.XPath, Using = ".//*[@id='checkboxes']/input[2]")]
        //IWebElement ele;
        //WindowsElement ele;
        //IMyElement ele;

        public IMyCheckBox FindSmth
        {
            get { return ele; }
        }
    }
}
