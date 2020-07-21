using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

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

        public object InvalidUsernameAndPasswordError { get; internal set; }

        //below are the list of properties
        public IWebElement Username => Driver.FindElement(By.Name("username"));
        public IWebElement Password => Driver.FindElement(By.Name("password"));
        public IWebElement LoginButton => Driver.FindElement(By.XPath("//*[@Type='submit']"));

        internal void RegisterNewUserAndSubmit(string firstName, string lastName, string address, string city, string state, string zipCode, string phone, string socialSecurityNumber, string userName, string password, string confirmPassword)
        {
            Driver.FindElement(By.LinkText("Register")).Click(); //clicks ths register link
            Driver.FindElement(By.Id("customer.firstName")).SendKeys(firstName); //this and following lines enter the user data
            Driver.FindElement(By.Id("customer.lastName")).SendKeys(lastName);
            Driver.FindElement(By.Id("customer.address.street")).SendKeys(address);
            Driver.FindElement(By.Id("customer.address.city")).SendKeys(city);
            Driver.FindElement(By.Id("customer.address.state")).SendKeys(state);
            Driver.FindElement(By.Id("customer.address.zipCode")).SendKeys(zipCode);
            Driver.FindElement(By.Id("customer.phoneNumber")).SendKeys(phone);
            Driver.FindElement(By.Id("customer.ssn")).SendKeys(socialSecurityNumber);
            Driver.FindElement(By.Id("customer.username")).SendKeys(userName);
            Driver.FindElement(By.Id("customer.password")).SendKeys(password);
            Driver.FindElement(By.Id("repeatedPassword")).SendKeys(confirmPassword);
            Driver.FindElement(By.XPath("//*[@value='Register']")).Click(); //clicks the register button
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            Assert.IsTrue(IsVisible);
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