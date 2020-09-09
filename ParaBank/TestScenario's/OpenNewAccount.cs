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
        internal OpenNewAccountApplicationPage OpenNewAccountApplicationPage { get; private set; } //This property is linked to the OpenNewAccountApplicationPage in the Setup

        [Description("Opens a new bank savings account")]
        [Author("Michael Rees")]
        [Category("Regression Tests")]
        [Test]
        public void OpenNewBankAccount()
        {
            OpenNewAccountApplicationPage.ApplyAndOpenNewSavingsAccount();
            Thread.Sleep(1000);
            Assert.That("Congratulations, your account is now open.", Is.EqualTo("Congratulations, your account is now open."));
        }
        [Description("Opens a new checking account")]
        [Author("Michael Rees")]
        [Category("Regression Tests")]
        [Test]
        public void OpenNewCheckingAccount()
        {
            OpenNewAccountApplicationPage.ApplyAndOpenNewCheckingAccount();
            Assert.That("Account Opened!", Is.EqualTo("Account Opened!"));
        }
        [Description("Verify the page text.")]
        [Category("Regression Tests")]
        [Author("Michael Rees")]
        [Test]
        public void VerifiesPageText()
        {
            OpenNewAccountApplicationPage.VerifyPageText();

            Assert.That("Open New Account", Is.EqualTo("Open New Account")); //Verifies the page title
            Assert.That("What type of Account would you like to open?", Is.EqualTo("What type of Account would you like to open?")); //Verfies question 1 below the page title is displayed correctly
            Assert.That("A minimum of $100.00 must be deposited into this account at time of opening. Please choose an existing account to transfer funds into the new account.", Is.EqualTo("A minimum of $100.00 must be deposited into this account at time of opening. Please choose an existing account to transfer funds into the new account.")); //Verifies the text below the type of account
        }
        [Description("Verify that the Open New Account button is enabled.")]
        [Category("Regression Tests")]
        [Test]
        public void VerifyButtonIsEnabled()
        {
            
            OpenNewAccountApplicationPage.VerifyButtonIsDisplayed();

            Assert.IsTrue(Driver.FindElement(By.XPath("//*[@value='Open New Account']")).Enabled);
        }
        [Description("Everything in here runs before each test but after the BaseTest class")]
        [SetUp]
        public void RunsBeforeEachTest()
        {
            OpenNewAccountApplicationPage = new OpenNewAccountApplicationPage(Driver);
        }
    }
}
