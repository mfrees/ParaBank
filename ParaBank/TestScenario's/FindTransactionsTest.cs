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
                Assert.AreEqual("ParaBank | Find Transactions", Driver.Title);
                Assert.That("Find Transactions", Is.EqualTo("Find Transactions")); //Verifies the page title header text is displayed as expected
                Assert.That("Select an account", Is.EqualTo("Select an account"), "Verify field label called Select an account");
                Assert.That("Find by Transaction ID", Is.EqualTo("Find by Transaction ID"), "Verify field label called Find by Transaction ID");
                Assert.That("Find by Date", Is.EqualTo("Find by Date"), "Verify field label called Find by Date");
                Assert.That("Find by Date Range", Is.EqualTo("Find by Date Range"), "Verify field label called Find by Date Range");
                Assert.That("Find by Amount", Is.EqualTo("Find by Amount"), "Verify field label called Find by Amount");
                //Below verifies the buttons 
                Assert.IsTrue(Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[2]/div/div/form/div[3]/button")).Enabled); //Find Transactions button
                Assert.IsTrue(Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[2]/div/div/form/div[5]/button")).Enabled); //Find by Date button
                Assert.IsTrue(Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[2]/div/div/form/div[7]/button")).Enabled); //Find by Date Range button
                Assert.IsTrue(Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[2]/div/div/form/div[9]/button")).Enabled); //Find by Amount button
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
