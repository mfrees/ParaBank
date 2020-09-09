using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;


namespace ParaBank
{
    [TestFixture]
    [Parallelizable]
    [Category("Regression Tests"), Category("Alerts")]
    public class TransferFundsTests : BaseTest
    {
        internal TransferFundsApplicationPage TransferFundsApplicationPage { get; private set; } //This property is linked to the TransferFundsApplicationPage in the setup

        [Description("Clicking the Transfer button without amount")]
        [Author("Michael Rees")]
        [Test]
        public void NegativeTestNoAmount()
        {
            TransferFundsApplicationPage.TransferWithNoAmount();
            Assert.That("The amount cannot be empty.", Is.EqualTo("The amount cannot be empty."));
        }
        [Description("Clicking the transfer button with characters in the amount field")]
        [Author("Michael Rees")]
        [Test]
        public void NegativeTestCharacters()
        {
            TransferFundsApplicationPage.TransferWithCharacters();
            Assert.That("Please enter a valid amount.", Is.EqualTo("Please enter a valid amount."));
        }
        [Description("Verify sub header and field labels.")]
        [Test]
        public void VerifiesSubHeaderAndFieldLabels()
        {
            
            TransferFundsApplicationPage.VerifySubHeaderAndFieldLabelText();
            Assert.That("Apply for a Loan", Is.EqualTo("Apply for a Loan"));
            Assert.That("Loan Amount:", Is.EqualTo("Loan Amount:"));
            Assert.That("Down Payment:", Is.EqualTo("Down Payment:"));
            Assert.That("From account #:", Is.EqualTo("From account #:"));
            Assert.IsTrue(Driver.FindElement(By.XPath("//*[@type='submit']")).Enabled);
        }
        [Description("Everything here runs before each test but after the BaseTest class")]
        [Author("Michael Rees")]
        [SetUp]
        public void RunsBeforeEachTest()
        {
            TransferFundsApplicationPage = new TransferFundsApplicationPage(Driver); //Creates the TransferFundsApplicationPage once instead of in each test
        }
    }
}
