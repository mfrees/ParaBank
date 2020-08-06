using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace ParaBank
{
    internal class LoginApplicationPage : BaseApplicationPage
    {
       

        public LoginApplicationPage(IWebDriver driver) : base(driver) { }
        

        public bool IsVisible //This object validates the login page is displayed
        {
            get
            {
                return Driver.Title.Contains("ParaBank | Welcome | Online Banking");
            }

            internal set { }
        }

        //public object InvalidUsernameAndPasswordError { get; internal set; }

        //below are the list of properties
        public IWebElement Username => Driver.FindElement(By.Name("username"));
        public IWebElement Password => Driver.FindElement(By.Name("password"));
        public IWebElement LoginButton => Driver.FindElement(By.XPath("//*[@Type='submit']"));
        public IWebElement RegisterLinkText => Driver.FindElement(By.LinkText("Register"));
        public IWebElement RegisterFirstName => Driver.FindElement(By.Id("customer.firstName"));
        public IWebElement RegisterLastName => Driver.FindElement(By.Id("customer.lastName"));
        public IWebElement RegisterAddress => Driver.FindElement(By.Id("customer.address.street"));
        public IWebElement RegisterCity => Driver.FindElement(By.Id("customer.address.city"));
        public IWebElement RegisterState => Driver.FindElement(By.Id("customer.address.state"));
        public IWebElement RegisterZipCode => Driver.FindElement(By.Id("customer.address.zipCode"));
        public IWebElement RegisterPhone => Driver.FindElement(By.Id("customer.phoneNumber"));
        public IWebElement RegisterSocialSecurityNumber => Driver.FindElement(By.Id("customer.ssn"));
        public IWebElement RegisterUsername => Driver.FindElement(By.Id("customer.username"));
        public IWebElement RegisterPassword => Driver.FindElement(By.Id("customer.password"));
        public IWebElement RegisterPasswordConfirm => Driver.FindElement(By.Id("repeatedPassword"));
        public IWebElement RegisterButton => Driver.FindElement(By.XPath("//*[@value='Register']"));

        internal void RegisterNewUserAndSubmit(RegisterUserInformation registeruserinformation)
        {
            RegisterLinkText.Click(); //clicks ths register link
            RegisterFirstName.SendKeys(registeruserinformation.FirstName); //populates the firstname field
            RegisterLastName.SendKeys(registeruserinformation.LastName); //populates the last name field
            RegisterAddress.SendKeys(registeruserinformation.Address); //populates the address
            RegisterCity.SendKeys(registeruserinformation.City); //populates the city field
            RegisterState.SendKeys(registeruserinformation.State); //populates the state field
            RegisterZipCode.SendKeys(registeruserinformation.ZipCode); //populates the zip code field
            RegisterPhone.SendKeys(registeruserinformation.Phone); //populates the phone field
            RegisterSocialSecurityNumber.SendKeys(registeruserinformation.SocialSecurityNumber); //populates the social security number
            RegisterUsername.SendKeys(registeruserinformation.Username); //populates the username field
            RegisterPassword.SendKeys(registeruserinformation.Password); //populates the password field
            RegisterPasswordConfirm.SendKeys(registeruserinformation.ConfirmPassword); //populates the confirm password field
            RegisterButton.Click(); //clicks the register button
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            Assert.IsTrue(IsVisible);
        }

        internal void ClickLoginButtonWithoutUsernameAndPassword()
        {
            LoginButton.Click();
        }

        internal accountsOverviewApplicationPage EnterValidCredentialsAndLogin(ValidLoginUser validuser)
        {
            Username.Clear(); //clear username field
            Username.SendKeys(validuser.Username); //enter username
            Password.Clear(); //clear the password field
            Password.SendKeys(validuser.Password); //enter the password
            LoginButton.Click(); //clicks the login button
            return new accountsOverviewApplicationPage(Driver);
        }

        internal void EnterInvalidCredentialsAndSubmit(InvalidLoginUser invaliduser)
        {
            Username.Clear(); //clear username field
            Username.SendKeys(invaliduser.Username); //enter username
            Password.Clear(); //clear the password field
            Password.SendKeys(invaliduser.Password); //enter the password
            LoginButton.Click(); //clicks the login button
            //return new accountsOverviewApplicationPage(Driver);
        }

        internal void ClickForgotLoginInfoLink()
        {
            Driver.FindElement(By.LinkText("Forgot login info?")).Click();
        }
    }
}