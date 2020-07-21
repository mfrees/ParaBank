using OpenQA.Selenium;

namespace ParaBank
{
    internal class accountsOverviewApplicationPage : BaseApplicationPage
    {
        

        public accountsOverviewApplicationPage(IWebDriver driver) : base(driver) { }
        
        public bool IsVisible => Driver.FindElement(By.XPath("//*[@class='smallText']")).Displayed; //this is a new way of implementing a getter
    }
}