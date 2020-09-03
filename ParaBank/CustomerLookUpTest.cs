using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace ParaBank
{
    [TestFixture]
    [Parallelizable]
    [Category("Regression Tests")]
    public class CustomerLookUpTest : BaseTest1
    {
        [Description("Verifies the page sub heading.")]
        [Author("Michael Rees")]
        [Test]
        public void VerifyPageText()
        {
            var customerlookuppage = new CustomerLookupPage(Driver);
            customerlookuppage.VerifyPageText();

            Assert.Multiple(testDelegate: () =>
            {
                Assert.That("Customer Lookup", Is.EqualTo("Customer Lookup"));
                Assert.That("Please fill out the following information in order to validate your account.", Is.EqualTo("Please fill out the following information in order to validate your account."));
                Assert.That("First Name:", Is.EqualTo("First Name:"));
                Assert.That("Last Name:", Is.EqualTo("Last Name:"));
                Assert.That("Address:", Is.EqualTo("Address:"));
                Assert.That("City:", Is.EqualTo("City:"));
                Assert.That("State:", Is.EqualTo("State:"));
                Assert.That("Zip Code:", Is.EqualTo("Zip Code:"));
                Assert.That("SSN:", Is.EqualTo("SSN:"));
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[@value='Find My Login Info']")).Displayed);
            });
        }
        [Description("Verify mandatory fields error's ")]
        [Author("Michael Rees")]
        [Test]
        public void VerifyManadtoryFieldAlerts()
        {
            var customerlookuppage = new CustomerLookupPage(Driver);
            customerlookuppage.VerifyMandatoryFieldWarnings();

            //One assertion per test rule is fine for unit tests, however as we progress up the testing stack there will be a need for multiple assertions.
            //We use the Assert.Multiple and then pass a Lambda function which contains multiple assertion statements
            Assert.Multiple(testDelegate: () =>
             {
                 Assert.That("First name is required.", Is.EqualTo("First name is required."));
                 Assert.That("Last name is required.", Is.EqualTo("Last name is required."));
                 Assert.That("Address is required.", Is.EqualTo("Address is required."));
                 Assert.That("City is required.", Is.EqualTo("City is required."));
                 Assert.That("State is required.", Is.EqualTo("State is required."));
                 Assert.That("Zip Code is required.", Is.EqualTo("Zip Code is required."));
                 Assert.That("Social Security Number is required.", Is.EqualTo("Social Security Number is required."));
             });
        }
        
    }
}
