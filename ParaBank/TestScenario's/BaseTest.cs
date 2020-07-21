using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ParaBank
{
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }

        [SetUp] //This class holds the setup and teardown which can be used by each test class.
        public void SetupForEverySingleTestMethod()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
        }

        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}