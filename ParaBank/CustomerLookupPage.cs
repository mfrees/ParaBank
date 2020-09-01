using OpenQA.Selenium;



namespace ParaBank
{
    internal class CustomerLookupPage : BaseApplicationPage

    {

        public CustomerLookupPage(IWebDriver driver) : base(driver) { }

        //Page objects below
        public IWebElement ForgotLoginInfoHyperLink => Driver.FindElement(By.LinkText("Forgot login info?"));
        public IWebElement FindMyLoginInfoButton => Driver.FindElement(By.XPath("//*[@value='Find My Login Info']"));


        internal void VerifyPageText()
        {
            ForgotLoginInfoHyperLink.Click();
        }

        internal void VerifyMandatoryFieldWarnings()
        {
            ForgotLoginInfoHyperLink.Click();
            FindMyLoginInfoButton.Click();
        }
    }
}