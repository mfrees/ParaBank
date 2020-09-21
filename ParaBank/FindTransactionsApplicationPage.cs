using OpenQA.Selenium;
using System;

namespace ParaBank
{
    internal class FindTransactionsApplicationPage :BaseApplicationPage
    {
        public FindTransactionsApplicationPage(IWebDriver driver): base(driver) { }

        //Below are the list of properties 
        public IWebElement FindTransactions => Driver.FindElement(By.LinkText("Find Transactions"));

        //Below are the methods 
        internal void VerifyPageText()
        {
            FindTransactions.Click();
        }
    }
}