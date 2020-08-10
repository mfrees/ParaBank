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
        [Description("Clicking the Transfer button without amount")]
        [Author("Michael Rees")]
        [Test]
        public void NegativeTestNoAmount()
        {
            var transferfundsapplicationpage = new TransferFundsApplicationPage(Driver);
            transferfundsapplicationpage.TransferWithNoAmount();
            Assert.That("The amount cannotg be empty.", Is.EqualTo("The amount cannotg be empty."));
        }
        [Description("Clicking the transfer button with characters in the amount field")]
        [Author("Michael Rees")]
        [Test]
        public void NegativeTestCharacters()
        {
            var transferfundsapplicationpage = new TransferFundsApplicationPage(Driver);
            transferfundsapplicationpage.TransferWithCharacters();
            Assert.That("Please enter a valid amount.", Is.EqualTo("Please enter a valid amount."));
        }
    }
}
