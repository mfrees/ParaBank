**ParaBank:**
Automation framework for a web based banking application. ParaBank is a website which has been set up for testing purposes.

**Motivation:**
My reasons for creating the project are for learning and improving my Selenium automation skills.

**Build Status:**

**Technology/Framework**

*Technology Used: C#, NUnit, Selenium, Visual Studio*

*Framework Used: Page Object Model*

**Coding Style:**

**Features:** 

**Code Example:**
*The following example is a test case class which has the test case linked to a specific feature.*

using NUnit.Framework;
using OpenQA.Selenium;

namespace ParaBank
{
    [TestFixture]
    [Parallelizable]
    [Category("Regression Tests"), Category("Alerts")]
    public class TransferFundsTests : BaseTest
    {
        [Description("Clicking the Transfer button without amount")]
        [Author("Michael Rees")]
        [Test]
        public void NegativeTestNoAmount()
        {
            var transferfundsapplicationpage = new TransferFundsApplicationPage(Driver);
            transferfundsapplicationpage.TransferWithNoAmount();
            Assert.That("The amount cannot be empty.", Is.EqualTo("The amount cannot be empty."));
        }

*Please see below for the corresponding page object class.*

using NUnit.Framework;
using OpenQA.Selenium;

namespace ParaBank
{
    internal class TransferFundsApplicationPage : BaseApplicationPage
    {
       

        public TransferFundsApplicationPage(IWebDriver driver) :base(driver) { }

        //below are the page objects
        public IWebElement TransferFundsLinkText => Driver.FindElement(By.LinkText("Transfer Funds"));
        public IWebElement TransferButton => Driver.FindElement(By.XPath("//*[@type='submit']"));
        public IWebElement AmountField => Driver.FindElement(By.Id("amount"));

        internal void TransferWithNoAmount()
        {
            TransferFundsLinkText.Click(); //clicks the Transfer Funds link text from left hand menu panel
            TransferButton.Click();

        }

**Installation:**

**Tests:**







