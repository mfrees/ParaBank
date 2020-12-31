using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace ParaBank
{
    [TestFixture]
    [Category("Radio Buttons"), Category("Regression Tests")]
    public class AdminPageTest :BaseTest1
    {
        internal AdminApplicationPage AdminApplicationPage { get; private set; } //This property is linked to the creation of the AdminApplicationPage in the Setup

        [Description("Initialise Database and verify alert message")]
        [Author("Michael Rees")]
        [Explicit("This has a big impact on the database and I only want to run this test when I specifically choose to.")]
        [Test]
        public void InitializeDatabase()
        {
            AdminApplicationPage.InitialiseDatabase();
            Assert.That(Driver.FindElement(By.XPath("//*[@id='rightPanel']/p/b")).Displayed);
            Assert.That("Database Initialized", Is.EqualTo("Database Initialized"));
        }

        [Description("Cleans the database and verifies alert message")]
        [Author("Michael Rees", "email can go here")]
        [Explicit("This has a big impact on the database and I only want to run this test when I specifically choose to.")]
        [Test]
        public void CleanDatabase()
        {
            AdminApplicationPage.CleanWebsite();
            Assert.That(Driver.FindElement(By.XPath("//*[@id='rightPanel']/p/b")).Displayed);
            Assert.That("Database Cleaned", Is.EqualTo("Database Cleaned"));
        }

        [Description("Stops and starts the JMS service.")]
        [Author("Michael Rees", "email")]
        [Explicit("This has a big impact on the database and I only want to run this test when I specifically choose to.")]
        [Test]
        public void StopAndStartService()
        {
            AdminApplicationPage.StopAndStartWebsiteService();
        }
        [Description("Everything in here runs before each test but after BaseClass1")]
        [SetUp]
        public void RunBeforeEachTest()
        {
            AdminApplicationPage = new AdminApplicationPage(Driver);
        }

    }
}
