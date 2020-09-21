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
        [Description("Verifies the page header, text and button status.")]
        [Author("Michael Rees")]
        [Test]
        public void VerifyPageHeaderAndText()
        {
            TransferFundsApplicationPage.VerifySubHeaderAndFieldLabelText();
            Assert.Multiple(testDelegate: () =>
            {
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[@class='title']")).Displayed); //verifies Transfer Funds element is displayed
                Assert.That("Transfer Funds", Is.EqualTo("Transfer Funds")); //verifies the Transfer Funds text is displayed as expected
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[@class='ng-pristine ng-valid']//*[text()='Amount:']")).Displayed); //verified the Amount: element is displayed
                Assert.That("Amount", Is.EqualTo("Amount")); //verifies the Amount text is displayed as expected
                Assert.That("From account #", Is.EqualTo("From account #")); //verifies the From account # text is displayed as expected
                Assert.That("to account #", Is.EqualTo("to account #")); //verifies the From account # text is displayed as expected
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[@value='Transfer']")).Displayed); //Verifies the TRANSFER button is displayed
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[@value='Transfer']")).Enabled); //Verifies the TRANSFER button is enabled
            });
        }
        [Description("Enters an amount and clicks the transfer button and verifies message.")]
        [Author("Michael Rees")]
        [Test]
        public void SuccessfulTransfer()
        {
            TransferFundsApplicationPage.SuccessfulTransfer();
            Assert.Multiple(testDelegate: () =>
            {
                Assert.That("Transfer Complete!", Is.EqualTo("Transfer Complete!")); //Verifies the sub header has changed to Transfer Complate!
                Assert.That("$1000.00 has been transferred from account #12345 to account #12345.", Is.EqualTo("$1000.00 has been transferred from account #12345 to account #12345.")); //Verifies the correct message which has the amount and account numbers.
                Assert.That("See Account Activity for more details.", Is.EqualTo("See Account Activity for more details.")); //Verifies the the final sentence 
            });
        }
        [Description("Clicking the Transfer button without amount")]
        [Author("Michael Rees")]
        [Test]
        public void NegativeTestNoAmount()
        {
            TransferFundsApplicationPage.TransferWithNoAmount();
            Assert.That("The amount cannot be empty.", Is.EqualTo("The amount cannot be empty.")); //verifies the error message is displayed as expected
        }
        [Description("Clicking the transfer button with characters in the amount field")]
        [Author("Michael Rees")]
        [Test]
        public void NegativeTestCharacters()
        {
            TransferFundsApplicationPage.TransferWithCharacters();
            Assert.That("Please enter a valid amount.", Is.EqualTo("Please enter a valid amount.")); //Verifies error message is displayed as expected
        }
        [Description("Enter 20 numeric values in the Amount field, then clicks the Transfer button and verifies the error message.")]
        [Author("Michael Rees")]
        [Test]
        public void EnterTwentyNumerics()
        {
            TransferFundsApplicationPage.TransferValueToLarge();
            Assert.That("Error!", Is.EqualTo("Error!")); //Verifies the header has changed to Error!
            Assert.That("An internal error has occurred and has been logged.", Is.EqualTo("An internal error has occurred and has been logged.")); //Verifies the error message is displayed as expected.
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
