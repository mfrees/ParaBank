using NUnit.Framework;
using OpenQA.Selenium;


namespace ParaBank
{
    [TestFixture]
    [Parallelizable]
    [Category("Regression Tests")]
    public class CustomerLookUpTest : BaseTest1
    {
        internal CustomerLookupPage CustomerLookUpPage { get; private set; } //This property is linked to the page creation in the setup 

        [Description("Verifies the page sub heading.")]
        [Author("Michael Rees")]
        [Test]
        public void VerifyPageText()
        {
            Assert.Multiple(testDelegate: () =>
            {
                Assert.That(Driver.FindElement(By.XPath("//*[@class='title']")).Displayed); //verifies the Customer Lookup element is displayed.
                Assert.That("Customer Lookup", Is.EqualTo("Customer Lookup"));
                Assert.That("Please fill out the following information in order to validate your account.", Is.EqualTo("Please fill out the following information in order to validate your account."));
                Assert.That(Driver.FindElement(By.XPath("//*[@class='form2']/tbody/tr/td/b")).Displayed); //Verifies the First Name element is displayed.
                Assert.That("First Name:", Is.EqualTo("First Name:"));
                Assert.That(Driver.FindElement(By.XPath("//*[@class='form2']/tbody/tr[2]/td/b")).Displayed); //verifies the Last Name element is displayed.
                Assert.That("Last Name:", Is.EqualTo("Last Name:"));
                Assert.That(Driver.FindElement(By.XPath("//*[@class='form2']/tbody/tr[3]/td/b")).Displayed); //verifies the Address element is displayed.
                Assert.That("Address:", Is.EqualTo("Address:"));
                Assert.That(Driver.FindElement(By.XPath("//*[@class='form2']/tbody/tr[4]/td/b")).Displayed); //verifies the City element is displayed.
                Assert.That("City:", Is.EqualTo("City:"));
                Assert.That(Driver.FindElement(By.XPath("//*[@class='form2']/tbody/tr[5]/td/b")).Displayed); //verifies the State element is displayed.
                Assert.That("State:", Is.EqualTo("State:"));
                Assert.That(Driver.FindElement(By.XPath("//*[@class='form2']/tbody/tr[6]/td/b")).Displayed); //verifies the Zip Code element is displayed.
                Assert.That("Zip Code:", Is.EqualTo("Zip Code:"));
                Assert.That(Driver.FindElement(By.XPath("//*[@class='form2']/tbody/tr[7]/td/b")).Displayed); //verifies the SSN element is displayed.
                Assert.That("SSN:", Is.EqualTo("SSN:"));
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[@value='Find My Login Info']")).Displayed);
            });
        }
        [Description("Verify mandatory fields error's")]
        [Author("Michael Rees")]
        [Test]
        public void VerifyManadtoryFieldAlerts()
        {
            CustomerLookUpPage.VerifyMandatoryFieldWarnings();

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
        [Description("Completes the form and submits then verifies the internal error message")]
        [Author("Michael Rees")]
        [Test]
        public void VerifyErrorMessage()
        {
            var customerlookupdetails = new CustomerLookupDetails();
            customerlookupdetails.FirstName = "John";
            customerlookupdetails.LastName = "Smith";
            customerlookupdetails.Address = "1431 Main St";
            customerlookupdetails.City = "Beverly Hills";
            customerlookupdetails.State = "CA";
            customerlookupdetails.ZipCode = "90210";
            customerlookupdetails.SSN = "310-447-4121";

            CustomerLookUpPage.CompleteFormAndSubmit(customerlookupdetails);

            Assert.That(Driver.FindElement(By.XPath("//*[@class='title']")).Displayed); //verifies that the Error! element is displayed.
            Assert.That("Error!", Is.EqualTo("Error!")); //verifies the Error! text.
            Assert.That(Driver.FindElement(By.XPath("//*[@class='error']")).Displayed); //verifies that the error message is displayed.
        }
        [Description("This is run before every test in this class but after the BaseTest1")]
        [SetUp]
        public void RunBeforeTest()
        {
            CustomerLookUpPage = new CustomerLookupPage(Driver);
            CustomerLookUpPage.NavigateToPage();
        }
    }
}
