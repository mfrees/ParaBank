using NUnit.Framework;
using System;
using System.Threading;

namespace ParaBank
{
    [TestFixture]
    [Parallelizable]
    [Category("Regression Tests")]
    public class UpdateContactInformationTest : BaseTest
    {
        internal UpdateContactInformationPage UpdateContactInformationPage { get; private set; } //This property is linked to the UpdateContactInformationPage creation in the Setup

        [Description("Change first name and last name then save and revert data to original")]
        [Test]
        public void ChangeFirstAndLastName()
        {
            UpdateContactInformationPage.ChangeFirstAndLastNameThenRevert();

            Assert.That("Profile Updated", Is.EqualTo("Profile Updated"));
            Assert.That("Your updated address and phone number have been added to the system.", Is.EqualTo("Your updated address and phone number have been added to the system."));
        }

        [Description("Clears all fields and asserts correct mandatory alerts are displayed")]
        [Author("Michael Rees")]
        [Test]
        public void ClearProfileAndSave()
        {
            
            UpdateContactInformationPage.ClearFormAndSave();
            Thread.Sleep(2000);

            //The following asserts the mandatory field alerts are displayed as expected
            Assert.That("First name is required.", Is.EqualTo("First name is required."));
            Assert.That("Last name is required.", Is.EqualTo("Last name is required."));
            Assert.That("Address is required.", Is.EqualTo("Address is required."));
            Assert.That("City is required.", Is.EqualTo("City is required."));
            Assert.That("State is required.", Is.EqualTo("State is required."));
            Assert.That("Zip Code is required.", Is.EqualTo("Zip Code is required."));
        }
        [Description("Everything in here is run before each test but after the BaseTest class")]
        [Author("Michael Rees")]
        [SetUp]
        public void RunsBeforeEachTest()
        {
            UpdateContactInformationPage = new UpdateContactInformationPage(Driver); //This creates the UpdateContactInformationPage once instead of in each test
        }
    }
}
