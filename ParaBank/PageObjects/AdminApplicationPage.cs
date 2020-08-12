using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace ParaBank
{
    internal class AdminApplicationPage : BaseApplicationPage
    {
        
        public AdminApplicationPage(IWebDriver driver): base(driver) { }

        //Page objects are listed below
        public IWebElement AdminPageLink => Driver.FindElement(By.LinkText("Admin Page"));
        public IWebElement InitializeButton => Driver.FindElement(By.XPath("//*[@value='INIT']"));
        public IWebElement CleanButton => Driver.FindElement(By.XPath("//*[@value='CLEAN']"));
        public IWebElement ShutdownButton => Driver.FindElement(By.XPath("//*[@value='Shutdown']"));
        public IWebElement StartUpButton => Driver.FindElement(By.XPath("//*[@value='Startup']"));
        internal void CleanWebsite()
        {
            AdminPageLink.Click();
            CleanButton.Click();
        }

        internal void InitialiseDatabase()
        {
            AdminPageLink.Click(); //clicks the Admin Page link on the left side bar
            InitializeButton.Click();
        }

        internal void StopAndStartWebsiteService()
        {
            AdminPageLink.Click();
            ShutdownButton.Click();
            Assert.That("Stopped", Is.EqualTo("Stopped"));
            StartUpButton.Click();
            Assert.That("Running", Is.EqualTo("Running"));
        }
    }
}