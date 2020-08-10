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
        [Description("Opens a new bank  savings account")]
        [Author("Michael Rees")]
        [Category("Regression Tests")]
        [Test]
        public void OpenNewBankAccount()
        {
            var opennewaccountapplicationpage = new OpenNewAccountApplicationPage(Driver);
            opennewaccountapplicationpage.ApplyAndOpenNewSavingsAccount();
            Thread.Sleep(1000);
            string matching_str = "Congratulations, your account is now open.";
            Assert.IsTrue(Driver.FindElement(By.TagName("body")).Text.Contains(matching_str));
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
        [Description("Verify the page header")]
        [Category("Regression Tests")]
        [Author("Michael Rees")]
        [Test]
        public void PageHeader()
        {
            var opennewaccountapplicationpage = new OpenNewAccountApplicationPage(Driver);
            opennewaccountapplicationpage.VerifyPageHeader();
        }
    }
}
