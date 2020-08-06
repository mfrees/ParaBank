﻿using System;
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
            string matching_str = "Your account was created successfully. You are now logged in.";
            Assert.IsTrue(Driver.FindElement(By.TagName("body")).Text.Contains(matching_str));
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
            String matching_str = "The username and password could not be verified.";
            Assert.IsTrue(Driver.FindElement(By.TagName("body")).Text.Contains(matching_str));
        }
        [Description("This test verifies the forgot login page is correctly displayed.")]
        [Author("MichaelRees")]
        [Test]
        public void ForgotLoginInfoLink()
        {
            var loginApplicationPage = new LoginApplicationPage(Driver);
            loginApplicationPage.GoTo();

            loginApplicationPage.ClickForgotLoginInfoLink();
            String matching_str = "Customer Lookup";
            Assert.IsTrue(Driver.FindElement(By.TagName("body")).Text.Contains(matching_str));
        }
        [Description("Click login button without entering a username and password.")]
        [Category("Regression Tests")]
        [Test]
        public void LogInErrorMessage()
        {
            var loginApplicationPage = new LoginApplicationPage(Driver);
            loginApplicationPage.GoTo();

            loginApplicationPage.LoginButton.Click();
            Assert.That("Please enter a username and password.", Is.EqualTo("Please enter a username and password."));
        }
    }
}