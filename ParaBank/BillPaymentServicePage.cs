using OpenQA.Selenium;
using System;

namespace ParaBank
{
    internal class BillPaymentServicePage : BaseApplicationPage
    {
        

        public BillPaymentServicePage(IWebDriver driver) :base(driver) { }

        //below are the list of properties
        public IWebElement BillPayLinkText => Driver.FindElement(By.LinkText("Bill Pay"));
        public IWebElement PayeeNameField => Driver.FindElement(By.Name("payee.name"));
        public IWebElement AddressField => Driver.FindElement(By.Name("payee.address.street"));
        public IWebElement CityField => Driver.FindElement(By.Name("payee.address.city"));
        public IWebElement StateField => Driver.FindElement(By.Name("payee.address.state"));
        public IWebElement ZipCodeField => Driver.FindElement(By.Name("payee.address.zipCode"));
        public IWebElement PhoneField => Driver.FindElement(By.Name("payee.phoneNumber"));
        public IWebElement AccountField => Driver.FindElement(By.Name("payee.accountNumber"));
        public IWebElement VerifyAccountField => Driver.FindElement(By.Name("verifyAccount"));
        public IWebElement AmountField => Driver.FindElement(By.Name("amount"));
        public IWebElement SendPaymentButton => Driver.FindElement(By.XPath("//*[@value='Send Payment']"));

        internal void FillOutFormAndSubmit(PayeeInformation payeeinformation)
        {
            BillPayLinkText.Click(); //clicks the bill pay link text
            PayeeNameField.SendKeys(payeeinformation.PayeeName); //populates the payee name field
            AddressField.SendKeys(payeeinformation.Address); //populates the address field
            CityField.SendKeys(payeeinformation.City); //populates the city field
            StateField.SendKeys(payeeinformation.State); //populates the state field
            ZipCodeField.SendKeys(payeeinformation.ZipCode); //populates zip code field
            PhoneField.SendKeys(payeeinformation.Phone); //populates the phone number field
            AccountField.SendKeys(payeeinformation.Account); //populates the account field
            VerifyAccountField.SendKeys(payeeinformation.VerifyAccount); //populates the verify account field
            AmountField.SendKeys(payeeinformation.Amount); //populates the amount field
            SendPaymentButton.Click(); //clicks the send payment button
        }

        internal void PayeeNameMandatoryField()
        {
            BillPayLinkText.Click(); //clicks the bill pay link text
            SendPaymentButton.Click(); //clicks the send payment button
        }
    }
}