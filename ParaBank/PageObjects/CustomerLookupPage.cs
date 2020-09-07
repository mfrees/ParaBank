using OpenQA.Selenium;
using System;

namespace ParaBank
{
    internal class CustomerLookupPage : BaseApplicationPage

    {
        public CustomerLookupPage(IWebDriver driver) : base(driver) { }

        //Page objects below
        public IWebElement ForgotLoginInfoHyperLink => Driver.FindElement(By.LinkText("Forgot login info?"));
        public IWebElement FindMyLoginInfoButton => Driver.FindElement(By.XPath("//*[@value='Find My Login Info']"));
        public IWebElement FirstNameField => Driver.FindElement(By.Id("firstName"));
        public IWebElement LastNameField => Driver.FindElement(By.Id("lastName"));
        public IWebElement AddressField => Driver.FindElement(By.Id("address.street"));
        public IWebElement CityField => Driver.FindElement(By.Id("address.city"));
        public IWebElement StateField => Driver.FindElement(By.Id("address.state"));
        public IWebElement ZipCodeField => Driver.FindElement(By.Id("address.zipCode"));
        public IWebElement SSNField => Driver.FindElement(By.Id("ssn"));

        //Methods below here

        internal void NavigateToPage()
        {
            ForgotLoginInfoHyperLink.Click();
        }
        internal void VerifyMandatoryFieldWarnings()
        {
            FindMyLoginInfoButton.Click();
        }

        internal void CompleteFormAndSubmit(CustomerLookupDetails customerlookupdetails)
        {
            FirstNameField.SendKeys(customerlookupdetails.FirstName);
            LastNameField.SendKeys(customerlookupdetails.LastName);
            AddressField.SendKeys(customerlookupdetails.Address);
            CityField.SendKeys(customerlookupdetails.City);
            StateField.SendKeys(customerlookupdetails.State);
            ZipCodeField.SendKeys(customerlookupdetails.ZipCode);
            SSNField.SendKeys(customerlookupdetails.SSN);
            FindMyLoginInfoButton.Click();
        }
    }
}