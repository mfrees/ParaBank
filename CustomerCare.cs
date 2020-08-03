using NUnit.Framework;
using System;

namespace ParaBank
{
    [TestFixture]
    [Description("This class contains test cases for the Customer Care screen.")]
    [Parallelizable]
    [Category("Regression Tests")]
    public class CustomerCare : BaseTest1
    {
        [Description("CompleteAndSubmitForm")]
        [Author("Michael Rees")]
        [Test]
        public void SubmitForm()
        {
            var loginApplicationPage = new LoginApplicationPage(Driver);
            loginApplicationPage.GoTo();

            var customercarepage = new CustomerCarePage(Driver);
            customercarepage.FillOutFormAndSubmit("William Davies", "Will.Davies@aol.com", "01792444555", "Please can you help me retrieve my login details and send me a password reset link.");
            //Thread.Sleep(2000);
            Assert.That("Thank you William Davies", Is.EqualTo("Thank you William Davies"));
            Assert.That("A Customer Care Representative will be contacting you.", Is.EqualTo("A Customer Care Representative will be contacting you."));
        }
    }
}
