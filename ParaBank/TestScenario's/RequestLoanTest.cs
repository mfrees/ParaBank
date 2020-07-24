using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace ParaBank
{
    [TestFixture]
    [Parallelizable]
    [Category("Request Loan")]
    public class RequestLoan : BaseTest
    {
        [Description("Apply for a loan ")]
        [Author("Michael Rees")]
        [Category("Regression Tests"), Category("Dropdown Lists")]
        [Test]
        public void ApplyForaLoan()
        {
            var requestloanapplicationpage = new RequestLoanApplicationPage(Driver);
            requestloanapplicationpage.ApplyAndSubmitLoanRequest("2000", "500");
            Thread.Sleep(1000);
            string matching_str = "Congratulations, your loan has been approved.";
            Assert.IsTrue(Driver.FindElement(By.TagName("body")).Text.Contains(matching_str));
        }
        [Description("Loan Amount and Down Payment fields not populated")]
        [Author("Michael Rees")]
        [Category("Regression Tests")]
        [Test]
        public void MandatoryFields()
        {
            var requestloanapplicationpage = new RequestLoanApplicationPage(Driver);
            requestloanapplicationpage.MandatoryFieldsCheck();
            Thread.Sleep(1000);
            string matching_str = "An internal error has occurred and has been logged.";
            Assert.IsTrue(Driver.FindElement(By.TagName("body")).Text.Contains(matching_str));
        }

    }
}
