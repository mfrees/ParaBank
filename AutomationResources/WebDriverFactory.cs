using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.IO;
using System.Reflection;

namespace AutomationResources
{
    //The purpose of this webdriverfactory class is to generate us our webdrivers. This class is not a test class it's a regualr class.
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            //This is a switch case statement to turn on our Chrome browser.
            switch (browserType)
            {
                case BrowserType.Edge:
                    return GetEdgeDriver();
                case BrowserType.Chrome:
                    return GetChromeDriver();
                default:
                    throw new ArgumentException("No such browser exists");
            }
         
        }
        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }

        private IWebDriver GetEdgeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new EdgeDriver(outPutDirectory);
        }

    }
}
