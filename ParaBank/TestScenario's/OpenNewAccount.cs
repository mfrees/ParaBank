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
            var validloginuser = new ValidLoginUser();
            validloginuser.Username = "john";
            validloginuser.Password = "demo";

            var loginApplicationPage = new LoginApplicationPage(Driver);
            loginApplicationPage.GoTo();
            loginApplicationPage.EnterValidCredentialsAndLogin(validloginuser);

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
            var validloginuser = new ValidLoginUser();
            validloginuser.Username = "john";
            validloginuser.Password = "demo";

            var loginApplicationPage = new LoginApplicationPage(Driver);
            loginApplicationPage.GoTo();
            loginApplicationPage.EnterValidCredentialsAndLogin(validloginuser);

            var opennewaccountapplicationpage = new OpenNewAccountApplicationPage(Driver);
            opennewaccountapplicationpage.ApplyAndOpenNewCheckingAccount();
            Assert.That("Account Opened!", Is.EqualTo("Account Opened!"));


        }
    }
}
