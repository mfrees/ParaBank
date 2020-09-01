using OpenQA.Selenium;
using System;
using System.Threading;

namespace ParaBank
{
    internal class UpdateContactInformationPage :BaseApplicationPage
    {

        public UpdateContactInformationPage(IWebDriver driver) :base(driver) { }

        //Below are the page objects
        public IWebElement FirstName => Driver.FindElement(By.Id("customer.firstName"));
        public IWebElement LastName => Driver.FindElement(By.Id("customer.lastName"));
        public IWebElement Address => Driver.FindElement(By.Id("customer.address.street"));

        public IWebElement City => Driver.FindElement(By.Id("customer.address.city"));
        public IWebElement State => Driver.FindElement(By.Id("customer.address.state"));
        public IWebElement ZipCode => Driver.FindElement(By.Id("customer.address.zipCode"));
        public IWebElement Phone => Driver.FindElement(By.Id("customer.phoneNumber"));
        public IWebElement UpdateProfileButton => Driver.FindElement(By.XPath("//*[@value='Update Profile']"));
        public IWebElement UpdateContactInfoLinkText => Driver.FindElement(By.LinkText("Update Contact Info"));

        internal void ClearFormAndSave()
        {
            UpdateContactInfoLinkText.Click();
            FirstName.Clear();
            LastName.Clear();
            Address.Clear();
            City.Clear();
            State.Clear();
            ZipCode.Clear();
            Phone.Clear();
            UpdateProfileButton.Click();
        }
        internal void ChangeFirstAndLastNameThenRevert()
        {
            UpdateContactInfoLinkText.Click();
            Thread.Sleep(2000);
            FirstName.Clear();
            FirstName.SendKeys("David");
            LastName.Clear();
            LastName.SendKeys("Jones");
            UpdateProfileButton.Click();
            UpdateContactInfoLinkText.Click();
            Thread.Sleep(2000);
            FirstName.Clear();
            FirstName.SendKeys("John");
            LastName.Clear();
            LastName.SendKeys("Smith");
            UpdateProfileButton.Click();
        }
    }
}