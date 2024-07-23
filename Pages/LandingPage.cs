using OpenQA.Selenium;

namespace AutomationWorkshop.Pages
{
    public class LandingPage
    {
        private IWebDriver browser;

        public LandingPage(IWebDriver driver)
        {
            browser = driver;
        }

        //locators
        private IWebElement RegisterLink => browser.FindElement(By.LinkText("Register"));

        //methods
        public RegisterPage GoToRegisterPage()
        {
            RegisterLink.Click();

            return new RegisterPage(browser);
        }

    }
}
