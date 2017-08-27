using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



    }
}
