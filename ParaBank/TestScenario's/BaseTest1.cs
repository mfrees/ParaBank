using AutomationResources;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ParaBank
{
    public class BaseTest1
    {
        public IWebDriver Driver { get; set; }

        [Description("No login included in this base test")]
        [SetUp] //This class holds the setup and teardown which can be used by each test class which references this class.
        public void SetupForEverySingleTestMethod()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            //Driver = factory.Create(BrowserType.Edge);

            //var loginApplicationPage = new LoginApplicationPage(Driver);
            //loginApplicationPage.GoTo();
        }

        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}