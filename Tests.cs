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
        [Retry(2)]
        public void Login()
        {
            HomePage homePage = new HomePage(_driver);
            LoginPage loginPage = new LoginPage(_driver);

            homePage.GoToLoginPage();
            loginPage.EnterCredentials("Jack99@testing.com", "Test123!");
            loginPage.ClickLogin();
        }

        [Test]
        [Retry(2)]
        public void SelectDropdownOption()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.GoToDropDownPage();

            By dropdownLocator = By.CssSelector("[id='fruits']");

            SeleniumHelpers.SelectDropDownValue(_driver, dropdownLocator, "Apple", "text");

            Assert.That(SeleniumHelpers.IsVisible(_driver.FindElement(dropdownLocator)) == false);
        }


        [Test]
        [Retry(2)]
        public void ConfirmButtonColour()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.GoToButtonsPage();

            var buttonColour = _driver.FindElement(By.Id("color")).GetCssValue("background-color");
            string[] rgbaValues = buttonColour.Replace("rgba(", "").Replace(")", "").Split(',');
            int r = int.Parse(rgbaValues[0].Trim());
            int g = int.Parse(rgbaValues[1].Trim());
            int b = int.Parse(rgbaValues[2].Trim());
            string actualColor = $"#{r:X2}{g:X2}{b:X2}";

            Assert.That(string.Compare(actualColor, "#8a4d76", StringComparison.OrdinalIgnoreCase) == 0);
        }

        [TearDown]
        public void TearDownTest()
        {
            LogTestDetails(_driver);
            _driver.Close();
        }
    }
}