using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace ParaBank
{
    internal class AdminApplicationPage : BaseApplicationPage
    {
        
        public AdminApplicationPage(IWebDriver driver): base(driver) { }

        internal void CleanWebsite()
        {
            Driver.FindElement(By.LinkText("Admin Page")).Click();
            Driver.FindElement(By.XPath("//*[@value='CLEAN']")).Click();
            String matching_str = "Database Cleaned";
            Assert.IsTrue(Driver.FindElement(By.TagName("body")).Text.Contains(matching_str));
        }
    }
}