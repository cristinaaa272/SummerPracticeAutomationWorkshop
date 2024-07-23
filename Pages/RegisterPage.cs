using AutomationWorkshop.Utils;
using OpenQA.Selenium;

namespace AutomationWorkshop.Pages
{
    public class RegisterPage
    {
        private IWebDriver browser;

        public RegisterPage(IWebDriver driver)
        {
            browser = driver;
        }

        //locators

        private IWebElement RegisterPageTitle => browser.FindElement(By.ClassName("title"));

        private IWebElement FirstName => browser.FindElement(By.Id("customer.firstName"));

        private IWebElement LastName => browser.FindElement(By.Id("customer.lastName"));

        private IWebElement Address => browser.FindElement(By.Id("customer.address.street"));

        private IWebElement City => browser.FindElement(By.Id("customer.address.city"));

        private IWebElement State => browser.FindElement(By.Id("customer.address.state"));

        private IWebElement ZipCode => browser.FindElement(By.Id("customer.address.zipCode"));

        private IWebElement PhoneNumber => browser.FindElement(By.Id("customer.phoneNumber"));

        private IWebElement SSN => browser.FindElement(By.Id("customer.ssn"));

        private IWebElement Username => browser.FindElement(By.Id("customer.username"));

        private IWebElement Password => browser.FindElement(By.Id("customer.password"));

        private IWebElement ConfirmPassword => browser.FindElement(By.Id("repeatedPassword"));

        private IWebElement RegisterButton => browser.FindElement(By.CssSelector("input[value='Register']"));

        //methods
        public string GetPageTitle()
        {
            return RegisterPageTitle.Text;
        }

        public AccountPage FillRegisterForm(User user)
        {
            FirstName.SendKeys(user.FirstName);
            LastName.SendKeys(user.LastName);
            Address.SendKeys(user.Address);
            City.SendKeys(user.City);
            State.SendKeys(user.State);
            ZipCode.SendKeys(user.Zipcode);
            PhoneNumber.SendKeys(user.Phone);
            SSN.SendKeys(user.SSN);
            Username.SendKeys(user.Username);
            Password.SendKeys(user.Password);
            ConfirmPassword.SendKeys(user.ConfirmPassword);

            RegisterButton.Click();

            return new AccountPage(browser);
        }
    }
}
