using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumC_.Helpers;
using SeleniumC_.Pages;

namespace SeleniumC_
{
    [TestFixture]
    public class Tests : TestBase
    {
        private IWebDriver _driver;


        [SetUp]
        public void SetupTest()
        {
            var driverPath = Environment.GetEnvironmentVariable("ChromeDriverPath");
            _driver = new ChromeDriver(driverPath);

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://letcode.in/test");

            StartExtentTest(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Login()
        {
            HomePage homePage = new HomePage(_driver);
            LoginPage loginPage = new LoginPage(_driver);

            homePage.GoToLoginPage();
            loginPage.EnterCredentials("Jack99@testing.com", "Test123!");
            loginPage.ClickLogin();
        }

        [Test]
        public void SelectDropdownOption()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.GoToDropDownPage();

            By dropdownLocator = By.CssSelector("[id='fruits']");

            SeleniumHelpers.SelectDropDownValue(_driver, dropdownLocator, "Apple", "text");

            Assert.That(SeleniumHelpers.IsVisible(_driver.FindElement(dropdownLocator)) == true);
        }


        [TearDown]
        public void TearDownTest()
        {
            LogTestDetails();
            _driver.Close();
        }
    }
}