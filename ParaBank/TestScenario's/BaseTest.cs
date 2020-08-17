using AutomationResources;
using CreatingReports;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ParaBank
{
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }

        [Description("Login included in this base test")]
        [SetUp] //This class holds the setup and teardown which can be used by each test class.
        public void SetupForEverySingleTestMethod()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);

            var validloginuser = new ValidLoginUser();
            validloginuser.Username = "john";
            validloginuser.Password = "demo";

            var loginApplicationPage = new LoginApplicationPage(Driver);
            loginApplicationPage.GoTo();
            loginApplicationPage.EnterValidCredentialsAndLogin(validloginuser);
        }

        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}