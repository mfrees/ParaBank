using OpenQA.Selenium;
using System.Threading;

namespace ParaBank
{
    internal class RequestLoanApplicationPage : BaseApplicationPage
    {

        public RequestLoanApplicationPage(IWebDriver driver): base(driver) { }

        //below are a list of properties
        public IWebElement RequestLoanLink => Driver.FindElement(By.LinkText("Request Loan"));
        public IWebElement LoanAmountField => Driver.FindElement(By.Id("amount"));
        public IWebElement DownPaymentField => Driver.FindElement(By.Id("downPayment"));
        public IWebElement ApplyNowButton => Driver.FindElement(By.XPath("//*[@value='Apply Now']"));

        //Methods below this point


        internal void ApplyAndSubmitLoanRequest(string loanAmount, string downPayment)
        {
            RequestLoanLink.Click(); //clicks the Request Loan link
            LoanAmountField.SendKeys(loanAmount); //populates the loan amount field
            DownPaymentField.SendKeys(downPayment); //populates the down payment field
            ApplyNowButton.Click(); // clicks the apply now button
        }

        internal void MandatoryFieldsCheck()
        {
            RequestLoanLink.Click(); //clicks the requests loan link
            Thread.Sleep(1000); //Wait
            ApplyNowButton.Click(); //clicks the apply now button
        }
    }
}