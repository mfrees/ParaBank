using NUnit.Framework;
using System;


namespace ParaBank
{
    [TestFixture]
    [Category("Radio Buttons"), Category("Regression Tests")]
    public class AdminPageTest :BaseTest1
    {
        [Description("Initialise Database and verify alert message")]
        [Author("Michael Rees")]
        [Explicit("This has a big impact on the database and I only want to run this test when I specifically choose to.")]
        [Test]
        public void InitializeDatabase()
        {
            var adminapplicationpage = new AdminApplicationPage(Driver);
            adminapplicationpage.InitialiseDatabase();

            Assert.That("Database Initialized", Is.EqualTo("Database Initialized"));
        }

        [Description("Cleans the database and verifies alert message")]
        [Author("Michael Rees", "email can go here")]
        [Explicit("This has a big impact on the database and I only want to run this test when I specifically choose to.")]
        [Test]
        public void CleanDatabase()
        {
            var adminapplicationpage = new AdminApplicationPage(Driver);
            adminapplicationpage.CleanWebsite();

            Assert.That("Database Cleaned", Is.EqualTo("Database Cleaned"));
        }

        [Description("Stops and starts the JMS service.")]
        [Author("Michael Rees", "email")]
        [Explicit("This has a big impact on the database and I only want to run this test when I specifically choose to.")]
        [Test]
        public void StopAndStartService()
        {
            var adminapplicationpage = new AdminApplicationPage(Driver);
            adminapplicationpage.StopAndStartWebsiteService();
        }

    }
}
