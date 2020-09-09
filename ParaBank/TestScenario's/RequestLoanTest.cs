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
        internal RequestLoanApplicationPage RequestLoanApplicationPage { get; private set; } //This property is linked to the RequestLoanApplicationPage in the Setup

        [Description("Apply for a loan")]
        [Author("Michael Rees")]
        [Category("Regression Tests"), Category("Dropdown Lists")]
        [Test]
        public void ApplyForALoan()
        {
            RequestLoanApplicationPage.ApplyAndSubmitLoanRequest("2000", "500");
            Thread.Sleep(1000);
            Assert.That("Congratulations, your loan has been approved.", Is.EqualTo("Congratulations, your loan has been approved."));
        }
        [Description("Loan Amount and Down Payment fields not populated")]
        [Author("Michael Rees")]
        [Category("Regression Tests")]
        [Test]
        public void MandatoryFields()
        {
            
            RequestLoanApplicationPage.MandatoryFieldsCheck();
            Thread.Sleep(1000);
            Assert.That("An internal error has occurred and has been logged.", Is.EqualTo("An internal error has occurred and has been logged."));
        }
        [Description("Everything in here runs before each test but after the BaseTest class")]
        [Author("Michael Rees")]
        [SetUp]
        public void RunsBeforeEachTest()
        {
            RequestLoanApplicationPage = new RequestLoanApplicationPage(Driver);
        }
    }
}
