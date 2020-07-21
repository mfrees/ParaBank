using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace ParaBank
{
    internal class OpenNewAccountApplicationPage :BaseApplicationPage
    {
        private IWebDriver driver;

        public OpenNewAccountApplicationPage(IWebDriver driver) : base(driver) { }

        public object OpenNewAccount { get; private set; }

        public IWebElement OpenNewAccountLinkText => Driver.FindElement(By.LinkText("Open New Account"));
        public IWebElement OpenNewAccountButton => Driver.FindElement(By.XPath("//*[@value='Open New Account']"));

        internal void ApplyAndOpenNewAccount()
        {
            OpenNewAccountLinkText.Click(); //clicks the open new account link text
            Driver.FindElement(By.XPath("//*[@value='1']")).Click(); //selects savings account
            Thread.Sleep(1000);
            OpenNewAccountButton.Click();//clicks the open new account button
        }
    }
}