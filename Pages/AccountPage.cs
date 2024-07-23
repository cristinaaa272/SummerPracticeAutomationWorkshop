using OpenQA.Selenium;

namespace AutomationWorkshop.Pages
{
    public class AccountPage
    {
        private IWebDriver browser;

        public AccountPage(IWebDriver driver)
        {
            browser = driver;
        }

        //locators
        private IWebElement SuccessMessage => browser.FindElement(By.CssSelector("div#rightPanel p"));

        private IWebElement LogOutLink => browser.FindElement(By.LinkText("Log Out"));

        //methods
        public bool IsSuccessMessageDisplayed()
        {
            return SuccessMessage.Displayed;
        }

        public LandingPage LogOut()
        {
            LogOutLink.Click();

            return new LandingPage(browser);
        }
    }
}
