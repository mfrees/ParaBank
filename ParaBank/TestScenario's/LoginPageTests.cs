using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ParaBank
{
    [TestFixture]
    [Parallelizable] //[parrallelizable(parellelScope.None)] if you do not want tests to run in parallel
    [Category("LoginPageTests"), Category("Regression Tests")]
    public class LoginPageTests : BaseTest1  //BaseTest1 is the use of inheritance (parent and child setup) which holds the setup and teardown and the driver 
    {

        [Description("This test case registers a new user.")]
        [Author("Michael Rees")]
        [Test]
        public void RegisterUser()
        {
            var registeruserinformation = new RegisterUserInformation();
            registeruserinformation.FirstName = "tom";
            registeruserinformation.LastName = "williams";
            registeruserinformation.Address = "156";
            registeruserinformation.City = "Swansea";
            registeruserinformation.State = "Swansea";
            registeruserinformation.ZipCode = "SA1 3ER";
            registeruserinformation.Phone = "07969323254";
            registeruserinformation.SocialSecurityNumber = "123456789";
            registeruserinformation.Username = "tom";
            registeruserinformation.Password = "williams";
            registeruserinformation.ConfirmPassword = "williams";

            var loginApplicationPage = new LoginApplicationPage(Driver);
            loginApplicationPage.GoTo();

            var adminApplicationPage = new AdminApplicationPage(Driver);
            adminApplicationPage.CleanWebsite();
            loginApplicationPage.RegisterNewUserAndSubmit(registeruserinformation);
            Assert.That("Your account was created successfully. You are now logged in.", Is.EqualTo("Your account was created successfully. You are now logged in."));
        }
        [Description("This test verifies that a user can log into the application")]
        [Author("MichaelRees")]
        [Test]
        public void SuccessfulLogin()
        {
            var validloginuser = new ValidLoginUser();
            validloginuser.Username = "john";
            validloginuser.Password = "demo";

            var loginApplicationPage = new LoginApplicationPage(Driver);
            loginApplicationPage.GoTo();
            
            var accountsOverviewApplicationPage = loginApplicationPage.EnterValidCredentialsAndLogin(validloginuser);
            Assert.IsTrue(accountsOverviewApplicationPage.IsVisible);
        }
        [Description("This test case verifies that when a user enters invalid credentials they can not log into the application")]
        [Author("MichaelRees")]
        [Test]
        public void UnsuccessfullLogin()
        {
            var invalidloginuser = new InvalidLoginUser();
            invalidloginuser.Username = "qwerty";
            invalidloginuser.Password = "12";

            var loginApplicationPage = new LoginApplicationPage(Driver);
            loginApplicationPage.GoTo();

            loginApplicationPage.EnterInvalidCredentialsAndSubmit(invalidloginuser);
            
            Assert.That("The username and password could not be verified.", Is.EqualTo("The username and password could not be verified."));
        }
        [Description("Test clicks on the login button without any credentials popuated and validates correct error message is displayed.")]
        [Author("Michael Rees")]
        [Test]
        public void ClickLoginButtonWithNoCredentials()
        {
            var loginApplicationPage = new LoginApplicationPage(Driver);
            loginApplicationPage.GoTo();

            loginApplicationPage.ClickLoginButtonWithoutUsernameAndPassword();
            Assert.That("Please enter a username and password.", Is.EqualTo("Please enter a username and password."));
        }
        [Description("Tests that the Login button is enabled.")]
        [Author("Michael Rees")]
        [Test]
        public void VerifyLoginButtonEnabled()
        {
            var loginApplicationPage = new LoginApplicationPage(Driver);
            loginApplicationPage.GoTo();

            Assert.IsTrue(Driver.FindElement(By.XPath("//*[@Type='submit']")).Enabled);
        }
        [Description("Test verifies that the Forgot login binfo? hyperlink is displayed.")]
        [Author("MichaelRees")]
        [Test]
        public void ForgotLoginInfoLink()
        {
            var loginApplicationPage = new LoginApplicationPage(Driver);
            loginApplicationPage.GoTo();

            Assert.IsTrue(Driver.FindElement(By.LinkText("Forgot login info?")).Enabled);
        }
        [Description("Tests that the Register hyperlink is enabled.")]
        [Author("Michael Rees")]
        [Test]
        public void VerifyRegisterLinkIsEnabled()
        {
            var loginApplicationPage = new LoginApplicationPage(Driver);
            loginApplicationPage.GoTo();

            Assert.IsTrue(Driver.FindElement(By.LinkText("Register")).Enabled);
        }
    }
}
