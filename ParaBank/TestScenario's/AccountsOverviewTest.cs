using NUnit.Framework;
using System;


namespace ParaBank
{
    [TestFixture]
    [Parallelizable]
    [Category("Accounts Overview Test Cases")]
    [Category("Regresstion Tests")]
    public class AccountsOverviewTest : BaseTest
    {
        [Description("Verify Page Header")]
        [Author("Michael Rees")]
        [Test]
        public void VerifyPageHeading()
        {
            var accountsoverviewapplicationpage = new AccountsOverviewApplicationPage(Driver);
            accountsoverviewapplicationpage.VerifyPageHeading();
        }
    }
}
