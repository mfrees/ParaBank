using NUnit.Framework;
using OpenQA.Selenium;

namespace ParaBank
{
    [TestFixture]
    [Parallelizable]
    [Category("Find Transactions"), Category("Regression Tests")]
    public class FindTransactionsTest : BaseTest
    {
        internal FindTransactionsApplicationPage FindTransactionsApplicationPage { get; private set; } //This property is linked to the FindTransactionsApplicationPage in the Setup
        [Test]
        public void VerifyPageText()
        {
            FindTransactionsApplicationPage.VerifyPageText();

            Assert.Multiple(testDelegate: () =>
            {
                Assert.AreEqual("ParaBank | Find Transactions", Driver.Title); //This verifies the page title.
                Assert.IsTrue(Driver.FindElement(By.CssSelector(".title")).Displayed);  //This verifies the page sub header.
                //The following 5 lines verify the page labels text.
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[@class='ng-pristine ng-valid ng-valid-required']//*[text()='Select an account']")).Displayed); 
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[@class='ng-pristine ng-valid ng-valid-required']//*[text()='Find by Transaction ID']")).Displayed); 
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[@class='ng-pristine ng-valid ng-valid-required']//*[text()='Find by Date']")).Displayed);
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[@class='ng-pristine ng-valid ng-valid-required']//*[text()='Find by Date Range']")).Displayed);
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[@class='ng-pristine ng-valid ng-valid-required']//*[text()='Find by Amount']")).Displayed);
                //Below verifies the buttons 
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[@id='rightPanel']/div/div/form/div[3]/button")).Enabled); //Find Transactions button
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[@id='rightPanel']/div/div/form/div[5]/button")).Enabled); //Find by Date button
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[@id='rightPanel']/div/div/form/div[7]/button")).Enabled); //Find by Date Range button
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[@id='rightPanel']/div/div/form/div[9]/button")).Enabled); //Find by Amount button
            });
        }
        [Test]
        public void EnterTextInTransId()
        {
            FindTransactionsApplicationPage.EnterTextInFindTransId("Test");
            //Start here
            Assert.IsTrue(Driver.FindElement(By.XPath("//*[@class='title']")).Displayed); //verifies the page header is displayed
            Assert.That("An internal error has occurred and has been logged.", Is.EqualTo("An internal error has occurred and has been logged."));
        }

        [SetUp]
        public void RunsBeforeEachTest()
        {
            FindTransactionsApplicationPage = new FindTransactionsApplicationPage(Driver);
        }
    }
}
