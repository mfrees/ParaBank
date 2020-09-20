using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace ParaBank
{
    [TestFixture]
    [Parallelizable]
    [Category("Regression Tests"), Category("Alerts")]
    public class TransferFundsTests : BaseTest
    {
        internal TransferFundsApplicationPage TransferFundsApplicationPage { get; private set; } //This property is linked to the TransferFundsApplicationPage in the setup
        [Test]
        public void VerifyPageHeaderAndText()
        {
            TransferFundsApplicationPage.VerifySubHeaderAndFieldLabelText();
            Assert.IsTrue(Driver.FindElement(By.XPath("//*[@class='title']")).Displayed);
            Assert.That("Transfer Funds", Is.EqualTo("Transfer Funds"));
            Assert.IsTrue(Driver.FindElement(By.XPath("//*[@class='ng-pristine ng-valid']//*[text()='Amount:']")).Displayed);
            Assert.That("Amount", Is.EqualTo("Amount"));
            //Assert.IsTrue(Driver.FindElement(By.XPath("")).Displayed);
            Assert.That("From account #", Is.EqualTo("From account #"));
            //Assert.IsTrue(Driver.FindElement(By.XPath("")).Displayed);
            Assert.That("to account #", Is.EqualTo("to account #"));

        }
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
        [Description("Everything here runs before each test but after the BaseTest class")]
        [Author("Michael Rees")]
        [SetUp]
        public void RunsBeforeEachTest()
        {
            TransferFundsApplicationPage = new TransferFundsApplicationPage(Driver); //Creates the TransferFundsApplicationPage once instead of in each test
        }
    }
}
