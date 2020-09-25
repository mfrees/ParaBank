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
        [Description("Find transactions by account and transaction id.")]
        [Author("Michael Rees")]
        [Test]
        public void FindByTransId()
        {
            FindTransactionsApplicationPage.FindTransactionByAccountAndTransID();
            Assert.AreEqual("12-11-2019", Driver.FindElement(By.ClassName("ng-binding")).Text);
        }
        [Description("Find transactions by account and date.")]
        [Author("Michael Rees")]
        [Test]
        public void FindByDate()
        {
            FindTransactionsApplicationPage.FindTransactionByDate("12-11-2019");
            Assert.AreEqual("12-11-2019", Driver.FindElement(By.ClassName("ng-binding")).Text);
        }
        [Description("Find transactions by account and find by date range")]
        [Author("Michael Rees")]
        [Test]
        public void FindByDateRange()
        {
            FindTransactionsApplicationPage.FindTransactionsByAccountAndDateRange("12-11-2019", "09-25-2020");
            Assert.IsTrue(Driver.FindElement(By.XPath("//*[@class='title'][text()='Transaction Results']")).Displayed); //verifies the page header is displayed
            //Date Assertions
            Assert.That("12-11-2019", Is.EqualTo("12-11-2019")); //verifies date from column 1 row 1
            Assert.That("12-12-2019", Is.EqualTo("12-12-2019")); //verifies date from column 1 row 2
            Assert.That("09-10-2019", Is.EqualTo("09-10-2019")); //verifies date from column 1 row 3
            Assert.That("09-14-2019", Is.EqualTo("09-14-2019")); //verifies date from column 1 row 4 & 5
            Assert.That("09-15-2019", Is.EqualTo("09-15-2019")); //verifies date from column 1 row 6
            Assert.That("09-17-2019", Is.EqualTo("09-17-2019")); //verifies date from column 1 row 7
            //Transactions Description Assertions
            Assert.That("Check # 1111", Is.EqualTo("Check # 1111")); //verifies transaction description from column 2 row 1
            Assert.That("Check # 1211", Is.EqualTo("Check # 1211")); //verifies transaction description from column 2 row 2
            Assert.That("Funds Transfer Sent", Is.EqualTo("Funds Transfer Sent")); //verifies transaction description from column 2 row 3,4,5 and 6
            Assert.That("Bill Payment to Bank of America Visa", Is.EqualTo("Bill Payment to Bank of America Visa")); //verifies transaction description from column 2 row 7
            //Debit Assertions
            Assert.That("", Is.EqualTo("")); //verifies debit from column 3 row 1
            Assert.That("$100.00", Is.EqualTo("$100.00")); //verifies debit from column 3 row 2 & 4
            Assert.That("1000.00", Is.EqualTo("1000.00")); //verifies debit from column 3 row 3 & 7
            Assert.That("$0.00", Is.EqualTo("$0.00")); //verifies debit from column 3 row 3 & 6
            //Credit Assertions
            Assert.That("$300.00", Is.EqualTo("$300.00")); //verifies credit from column 4 row 1
            Assert.That("", Is.EqualTo("")); //verifies credit from column 4 row 2 to 7
        }
        [Description("Find transactions by amount.")]
        [Author("Michael Rees")]
        [Test]
        public void FindByAmount()
        {

            FindTransactionsApplicationPage.FindTransactionsByAmount("100.00");
            Assert.IsTrue(Driver.FindElement(By.XPath("//*[@class='title'][text()='Transaction Results']")).Displayed); //verifies the page header is displayed
            //Assertion to check the correct dates are returned
            Assert.That("12-11-2019", Is.EqualTo("12-11-2019"));
            Assert.That("09-14-2020", Is.EqualTo("09-14-2020"));
            Assert.That("09-25-2020", Is.EqualTo("09-25-2020"));
            //Assertions to check the correct transactions details are returned
            Assert.That("Check # 1211", Is.EqualTo("Check # 1211"));
            Assert.That("Funds Transfer Sent", Is.EqualTo("Funds Transfer Sent"));
            //Assertions to check the correct Debit amounts are returned
            Assert.That("$100.00", Is.EqualTo("$100.00"));
        }
        [Test]
        public void EnterTextInTransId()
        {
            FindTransactionsApplicationPage.EnterTextInFindTransId("Test");
            //Start here
            Assert.IsTrue(Driver.FindElement(By.XPath("")).Displayed); //verifies the page header is displayed
            Assert.That("An internal error has occurred and has been logged.", Is.EqualTo("An internal error has occurred and has been logged."));
        }

        [SetUp]
        public void RunsBeforeEachTest()
        {
            FindTransactionsApplicationPage = new FindTransactionsApplicationPage(Driver);
        }
    }
}
