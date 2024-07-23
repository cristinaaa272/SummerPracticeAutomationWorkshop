using AutomationWorkshop.Pages;
using AutomationWorkshop.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationWorkshop.Tests
{
    [TestClass]
    public class UserBehaviorTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
        }

        [TestCleanup]
        public void CleanupTest()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Should_CreateUserAccount_When_RegisterFormContainsValidData()
        {
            //go to register page
            var landingPage = new LandingPage(driver);
            var registerPage = landingPage.GoToRegisterPage();

            //assert: user has reached correct page
            var expectedTitle = "Signing up is easy!";
            var actualTitle = registerPage.GetPageTitle();

            Assert.AreEqual(expectedTitle, actualTitle);

            //fill in register form
            User user = new User()
            {
                FirstName = "cristina",
                LastName = "test",
                Address = "iasi",
                City = "Iasi",
                State = "Romania",
                Zipcode = "123456",
                Phone = "123456789",
                SSN = "0000000",
                Username = "cristina_test_2",
                Password = "SummerPractice01.",
                ConfirmPassword = "SummerPractice01."
            };

            var accountPage = registerPage.FillRegisterForm(user);

            //assert: check if user account has been created

            Assert.IsTrue(accountPage.IsSuccessMessageDisplayed());

            //logout
            accountPage.LogOut();
        }
    }
}