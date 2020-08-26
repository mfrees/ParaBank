using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace ParaBank
{
    internal class OpenNewAccountApplicationPage :BaseApplicationPage
    {

        public OpenNewAccountApplicationPage(IWebDriver driver) : base(driver) { }

        //public object OpenNewAccount { get; private set; }

        public IWebElement OpenNewAccountLinkText => Driver.FindElement(By.LinkText("Open New Account"));
        public IWebElement OpenNewAccountButton => Driver.FindElement(By.XPath("//*[@value='Open New Account']"));

        internal void ApplyAndOpenNewSavingsAccount()
        {
            OpenNewAccountLinkText.Click(); //clicks the open new account link text
            Driver.FindElement(By.XPath("//*[@value='1']")).Click(); //selects savings account
            Thread.Sleep(1000); //wait
            OpenNewAccountButton.Click();//clicks the open new account button
        }

        internal void ApplyAndOpenNewCheckingAccount()
        {
            OpenNewAccountLinkText.Click(); //clicks the open new account link text
            OpenNewAccountButton.Click(); //clicks the open new account button
        }

        internal void VerifyPageText()
        {
            OpenNewAccountLinkText.Click();
            Assert.That("Open New Account", Is.EqualTo("Open New Account")); //page sub header
            Assert.That("What type of Account would you like to open?", Is.EqualTo("What type of Account would you like to open?")); //question 1
            Assert.That("A minimum of $100.00 must be deposited into this account at time of opening. Please choose an existing account to transfer funds into the new account.", Is.EqualTo("A minimum of $100.00 must be deposited into this account at time of opening. Please choose an existing account to transfer funds into the new account.")); //question 2&3
        }

        internal void VerifyButtonIsDisplayed()
        {
            OpenNewAccountLinkText.Click();
            Assert.IsTrue(Driver.FindElement(By.XPath("//*[@value='Open New Account']")).Enabled);
        }
    }
}