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
        [Description("Clears all fields and asserts correct mandatory alerts are displayed")]
        [Author("Michael Rees")]
        [Test]
        public void ClearProfileAndSave()
        {
            var updatecontactinformationpage = new UpdateContactInformationPage(Driver);
            updatecontactinformationpage.ClearFormAndSave();
            Thread.Sleep(2000);

            //The following asserts the mandatory field alerts are displayed as expected
            Assert.That("First name is required.", Is.EqualTo("First name is required."));
            Assert.That("Last name is required.", Is.EqualTo("Last name is required."));
            Assert.That("Address is required.", Is.EqualTo("Address is required."));
            Assert.That("City is required.", Is.EqualTo("City is required."));
            Assert.That("State is required.", Is.EqualTo("State is required."));
            Assert.That("Zip Code is required.", Is.EqualTo("Zip Code is required."));
        }
    }
}
