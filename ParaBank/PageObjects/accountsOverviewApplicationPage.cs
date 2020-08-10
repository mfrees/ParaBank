using NUnit.Framework;
using OpenQA.Selenium;


namespace ParaBank
{
    internal class AccountsOverviewApplicationPage : BaseApplicationPage
    {
        

        public AccountsOverviewApplicationPage(IWebDriver driver) : base(driver) { }
        
        public bool IsVisible => Driver.FindElement(By.XPath("//*[@class='smallText']")).Displayed; //Getter. I need to change this when I introduce a left side panel class. This is the welcome firstname lastname message
        //public bool IsVisible => Driver.FindElement(By.XPath("//*[@class='title']")).Displayed;

        //Below are the list of page objects
        public IWebElement AccountsOverviewLinkText => Driver.FindElement(By.LinkText("Accounts Overview"));
        internal void VerifyPageHeading()
        {
            AccountsOverviewLinkText.Click();
            Assert.That("Accounts Overview", Is.EqualTo("Accounts Overview"));
        }
    }
}