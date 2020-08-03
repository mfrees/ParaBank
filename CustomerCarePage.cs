using OpenQA.Selenium;
using System;

namespace ParaBank
{
    internal class CustomerCarePage : BaseApplicationPage
    {
        public CustomerCarePage(IWebDriver driver) :base(driver) { }
        //below are the list of properties for the Customer Care Page
        public IWebElement ContactButton => Driver.FindElement(By.LinkText("contact"));
        public IWebElement NameField => Driver.FindElement(By.Id("name"));
        public IWebElement EmailFiled => Driver.FindElement(By.Id("email"));
        public IWebElement PhoneField => Driver.FindElement(By.Id("phone"));
        public IWebElement MessageBox => Driver.FindElement(By.Id("message"));
        public IWebElement SendToCutomerCareButton => Driver.FindElement(By.XPath("//*[@value='Send to Customer Care']"));


        internal void FillOutFormAndSubmit(string nameField, string emailField, string phoneField, string messageField)
        {
            //Tidy this up next
            ContactButton.Click(); //click the contact button in below welcome to ParaBank
            NameField.SendKeys(nameField); //populates the name field
            EmailFiled.SendKeys(emailField); //populates the email field
            PhoneField.SendKeys(phoneField);//populates the phone field
            MessageBox.SendKeys(messageField); //populates the message box
            SendToCutomerCareButton.Click(); //clicks the send to customer care button
        }
    }
}