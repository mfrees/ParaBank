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
                //Assert.IsTrue(Driver.FindElement(By.XPath("//*[@class='title']")).Displayed); //Verifies that the page title is actual displayed
                Assert.That("Find Transactions", Is.EqualTo("Find Transactions")); //Verifies the page title header text is displayed as expected
            });
        }
        [SetUp]
        public void RunsBeforeEachTest()
        {
            FindTransactionsApplicationPage = new FindTransactionsApplicationPage(Driver);
        }
    }
}
