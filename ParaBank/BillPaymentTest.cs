using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace ParaBank
{
    [TestFixture]
    [Parallelizable]
    [Category("Regression"), Category("Text Fields")]
    public class BillPaymentTest : BaseTest
    {
        [Test]
        public void EnterPayeeInfo()
        {
            var validloginuser = new ValidLoginUser();
            validloginuser.Username = "john";
            validloginuser.Password = "demo";

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

            var loginApplicationPage = new LoginApplicationPage(Driver);
            loginApplicationPage.GoTo();
            loginApplicationPage.EnterValidCredentialsAndLogin(validloginuser);

            var billpaymentservicepage = new BillPaymentServicePage(Driver);
            billpaymentservicepage.FillOutFormAndSubmit(payeeinformation);
            Thread.Sleep(2000);
            string matching_str = "Bill Payment to William Davies in the amount of $10.00";
            Assert.IsTrue(Driver.FindElement(By.TagName("body")).Text.Contains(matching_str));
        }
        [Description("Payee Name field not populated")]
        [Author("Michael Rees")]
        [Test]
        public void PayeeNameMandatoryFieldError()
        {
            var validloginuser = new ValidLoginUser();
            validloginuser.Username = "john";
            validloginuser.Password = "demo";

            var loginApplicationPage = new LoginApplicationPage(Driver);
            loginApplicationPage.GoTo();
            loginApplicationPage.EnterValidCredentialsAndLogin(validloginuser);


            var billpaymentservicepage = new BillPaymentServicePage(Driver);
            billpaymentservicepage.PayeeNameMandatoryField();
            Thread.Sleep(1000);
            Assert.That("Payee name is required.", Is.EqualTo("Payee name is required."));
        }
    }
}
