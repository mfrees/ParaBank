using OpenQA.Selenium;
using System;
using System.Threading;

namespace ParaBank
{
    internal class FindTransactionsApplicationPage :BaseApplicationPage
    {
        public FindTransactionsApplicationPage(IWebDriver driver): base(driver) { }

        //Below are the list of properties 
        public IWebElement FindTransactions => Driver.FindElement(By.LinkText("Find Transactions"));
        public IWebElement AccountList => Driver.FindElement(By.Id("accountId"));
        public IWebElement FindByTransIDField => Driver.FindElement(By.Id("criteria.transactionId"));
        public IWebElement FindTransactionsButtonID => Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[2]/div/div/form/div[3]/button")); //Find Transactions button in the Find by Transaction ID section
        public IWebElement FindByDateField => Driver.FindElement(By.Id("criteria.onDate"));
        public IWebElement FindTransactionsButtonDate => Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[2]/div/div/form/div[5]/button")); //Find Transactions button in the Find By Date section
        public IWebElement DateRangeBetweenField => Driver.FindElement(By.Id("criteria.fromDate"));
        public IWebElement DateRangeAndField => Driver.FindElement(By.Id("criteria.toDate"));

        public IWebElement FindTransactionsButtonDateRange => Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[2]/div/div/form/div[7]/button")); //Find Transactions button in the Find by Date Range section
        public IWebElement FindByAmountField => Driver.FindElement(By.Id("criteria.amount"));
        public IWebElement FindTransactionsButtonAmount => Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[2]/div/div/form/div[9]/button")); //Find Transaction button in the Find by Amount section

        //Below are the methods 
        internal void VerifyPageText()
        {
            FindTransactions.Click();
        }
        internal void EnterTextInFindTransId(string text)
        {
            FindTransactions.Click();
            FindByTransIDField.Clear();
            FindByTransIDField.SendKeys(text);
            FindTransactionsButtonID.Click();
            Thread.Sleep(1000);
        }
    }
}