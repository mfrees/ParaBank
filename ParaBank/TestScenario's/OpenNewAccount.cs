using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ParaBank
{
    [TestFixture]
    [Parallelizable]
    [Category("Open New Account")]
    public class OpenNewAccount : BaseTest
    {
        [Description("Opens a new bank savings account")]
        [Author("Michael Rees")]
        [Category("Regression Tests")]
        [Test]
        public void OpenNewBankAccount()
        {
            var opennewaccountapplicationpage = new OpenNewAccountApplicationPage(Driver);
            opennewaccountapplicationpage.ApplyAndOpenNewSavingsAccount();
            Thread.Sleep(1000);
            Assert.That("Congratulations, your account is now open.", Is.EqualTo("Congratulations, your account is now open."));
        }
        [Description("Opens a new checking account")]
        [Author("Michael Rees")]
        [Category("Regression Tests")]
        [Test]
        public void OpenNewCheckingAccount()
        {
            var opennewaccountapplicationpage = new OpenNewAccountApplicationPage(Driver);
            opennewaccountapplicationpage.ApplyAndOpenNewCheckingAccount();
            Assert.That("Account Opened!", Is.EqualTo("Account Opened!"));
        }
        [Description("Verify the page text.")]
        [Category("Regression Tests")]
        [Author("Michael Rees")]
        [Test]
        public void VerifiesPageText()
        {
            var opennewaccountapplicationpage = new OpenNewAccountApplicationPage(Driver);
            opennewaccountapplicationpage.VerifyPageText();

            Assert.That("Open New Account", Is.EqualTo("Open New Account")); //page sub header
            Assert.That("What type of Account would you like to open?", Is.EqualTo("What type of Account would you like to open?")); //question 1
            Assert.That("A minimum of $100.00 must be deposited into this account at time of opening. Please choose an existing account to transfer funds into the new account.", Is.EqualTo("A minimum of $100.00 must be deposited into this account at time of opening. Please choose an existing account to transfer funds into the new account.")); //question 2&3
        }
        [Description("Verify that the Open New Account button is enabled.")]
        [Category("Regression Tests")]
        [Test]
        public void VerifyButtonIsEnabled()
        {
            var opennewaccountapplicationpage = new OpenNewAccountApplicationPage(Driver);
            opennewaccountapplicationpage.VerifyButtonIsDisplayed();

            Assert.IsTrue(Driver.FindElement(By.XPath("//*[@value='Open New Account']")).Enabled);
        }
    }
}
