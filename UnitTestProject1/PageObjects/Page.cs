using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Elements;

namespace UnitTestProject1.PageObjects
{
    public class Page
    {
        IWebDriver driver;
        public Page(IWebDriver driver)
        {
            this.driver = driver;
            //This initElements method will create all WebElements
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = ".//*[@id='checkboxes']/input[2]")]
        IWebElement ele;


        public void FindSmoth()
        {
            ele.Click();
        }

    }
}
