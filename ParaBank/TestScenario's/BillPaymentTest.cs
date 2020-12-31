using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace ParaBank
{
    [TestFixture]
    [Parallelizable]
    [Category("Regression Tests"), Category("Text Fields")]
    public class BillPaymentTest : BaseTest
    {
        internal BillPaymentServicePage BillPaymentServicePage { get; private set; } //Property for creating the BillPaymentServicePage in the setup

        
        [Author("Michael Rees")]
        [Test]
        public void EnterPayeeInfo()
        {
            var payeeinformation = new PayeeInformation();
            payeeinformation.PayeeName = "William Davies";
            payeeinformation.Address = "123 Williams Terrace";
            payeeinformation.City = "Perth";
            payeeinformation.State = "Pudsey";
            payeeinformation.ZipCode = "LS28 5ER";
            payeeinformation.Phone = "07821546592";
            payeeinformation.Account = "81779855";
            payeeinformation.VerifyAccount = "81779855";
            payeeinformation.Amount = "10.00";

            BillPaymentServicePage.FillOutFormAndSubmit(payeeinformation);
            Thread.Sleep(2000);
            Assert.That(Driver.FindElement(By.XPath("//*[@id='rightPanel']/div/div/h1")).Displayed);
            Assert.That("Bill Payment to William Davies in the amount of $10.00", Is.EqualTo("Bill Payment to William Davies in the amount of $10.00"));
        }
        [Description("Click Sending Payment button with no fields populated to test mandatory field warnings.")]
        [Author("Michael Rees")]
        [Test]
        public void TextAndMandatoryFieldWarnings()
        {
            BillPaymentServicePage.TextAndFieldMandatoryFieldWarnings();
            Thread.Sleep(1000);
            Assert.That(Driver.FindElement(By.XPath("//*[@id='rightPanel']/div/div/h1")).Displayed); //Verifies the page title element is displayed.
            Assert.That("Bill Payment Service", Is.EqualTo("Bill Payment Service")); //Verifies the page title
            Assert.That(Driver.FindElement(By.XPath("//*[@id='rightPanel']/div/div/p")).Displayed); //Verifies the sentence below the page title element is displayed.
            Assert.That("Enter payee information", Is.EqualTo("Enter payee information")); //Verifies sentence below the page title
            Assert.That("Payee name is required.", Is.EqualTo("Payee name is required.")); //Verifies the Payee Name mandatory field
            Assert.That("Address is required.", Is.EqualTo("Address is required.")); //Verifies the Address field mandatory field warning
            Assert.That("City is required.", Is.EqualTo("City is required.")); //Verifies the City mandatory field warning
            Assert.That("State is required.", Is.EqualTo("State is required.")); //Verifies the State field mandatory field warning
            Assert.That("Zip Code is required.", Is.EqualTo("Zip Code is required.")); //Verifies the Zip Code code mandatory field warning
            Assert.That("Phone number is required.", Is.EqualTo("Phone number is required.")); //Verifies the Phone mandatory field warning
            Assert.That("Account number is required.", Is.EqualTo("Account number is required.")); //Verifies the Account mandatory field warning
            Assert.That("The amount cannot be empty. ", Is.EqualTo("The amount cannot be empty. ")); //Verifies the Amount field mandatory field warning
        }
        [Description("Entering text in numeric fields and cliking Send Payment button")]
        [Author("Michael Rees")]
        [Test]
        public void TextInNumericFields()
        {
            var payeeinformation = new PayeeInformation();
            payeeinformation.Phone = "text";
            payeeinformation.Account = "text";
            payeeinformation.VerifyAccount = "text";
            payeeinformation.Amount = "text";

            BillPaymentServicePage.EnterTextInNumericFields(payeeinformation);

            
            Assert.That("Please enter a valid number.", Is.EqualTo("Please enter a valid number."));
            Assert.That("Please enter a valid amount.", Is.EqualTo("Please enter a valid amount."));
        }
        [Description("Everything in here runs before each test but after the base test")]
        [SetUp]
        public void RunBeforeEachTest()
        {
            BillPaymentServicePage = new BillPaymentServicePage(Driver); //We are creating the BillPaymentServicePage here once rather than in evry test.
        }
    }
}
