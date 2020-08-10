﻿using OpenQA.Selenium;
using System;

namespace ParaBank
{
    internal class TransferFundsApplicationPage : BaseApplicationPage
    {
        private IWebDriver driver;

        public TransferFundsApplicationPage(IWebDriver driver) :base(driver) { }

        //below are the page objects
        public IWebElement TransferFundsLinkText => Driver.FindElement(By.LinkText("Transfer Funds"));
        public IWebElement TransferButton => Driver.FindElement(By.XPath("//*[@type='submit']"));
        public IWebElement AmountField => Driver.FindElement(By.Id("amount"));
        internal void TransferWithNoAmount()
        {
            TransferFundsLinkText.Click(); //clicks the Transfer Funds link text from left hand menu panel
            TransferButton.Click();

        }

        internal void TransferWithCharacters() //tidy this up when next in this class
        {
            TransferFundsLinkText.Click(); //clicks the Transfer Funs link text from left side panel
            AmountField.Clear(); //clears the amount field
            AmountField.SendKeys("test"); //enters characters in the amount field
            TransferButton.Click(); //clicks the transfer button
        }
    }
}