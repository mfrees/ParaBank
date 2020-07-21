//This is a base page which has a reference of our driver which can be used by all the pages which cuts down on code duplication.
using OpenQA.Selenium;

namespace ParaBank
{
    internal class BaseApplicationPage
    {
        protected IWebDriver Driver { get; set; }

        public BaseApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}