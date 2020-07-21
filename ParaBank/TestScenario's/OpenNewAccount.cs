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
        [Description("Opens a new bank account")]
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
            opennewaccountapplicationpage.ApplyAndOpenNewAccount();
            Thread.Sleep(1000);
            string matching_str = "Congratulations, your account is now open.";
            Assert.IsTrue(Driver.FindElement(By.TagName("body")).Text.Contains(matching_str));
        }
    }
}
