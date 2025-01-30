using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumC_.Helpers;
using SeleniumC_.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumC_
{
    [TestFixture]
    public class Tests : TestBase
    {
        private IWebDriver _driver;
        private HomePage _homePage;


        [SetUp]
        public void SetupTest()
        {
            new DriverManager().SetUpDriver(new ChromeConfig()); 
            _driver = new ChromeDriver();

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://letcode.in/test");

            _homePage = new HomePage(_driver);

            StartExtentTest(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        [Retry(2)]
        public void Login()
        {
            LoginPage loginPage = new LoginPage(_driver);

            _homePage.GoToLoginPage();
            loginPage.EnterCredentials("Jack99@testing.com", "Test123!");
            loginPage.ClickLogin();
        }

        [Test]
        [Retry(2)]
        public void SelectDropdownOption()
        {
            _homePage.GoToDropDownPage();

            By dropdownLocator = By.CssSelector("[id='fruits']");

            SeleniumHelpers.SelectDropDownValue(_driver, dropdownLocator, "Apple", "text");

            Assert.That(SeleniumHelpers.IsVisible(_driver.FindElement(dropdownLocator)) == true);
        }


        [Test]
        [Retry(2)]
        public void ConfirmButtonColour()
        {
            _homePage.GoToButtonsPage();

            var buttonColour = _driver.FindElement(By.Id("color")).GetCssValue("background-color");
            string[] rgbaValues = buttonColour.Replace("rgba(", "").Replace(")", "").Split(',');
            int r = int.Parse(rgbaValues[0].Trim());
            int g = int.Parse(rgbaValues[1].Trim());
            int b = int.Parse(rgbaValues[2].Trim());
            string actualColor = $"#{r:X2}{g:X2}{b:X2}";

            Assert.That(string.Compare(actualColor, "#8a4d76", StringComparison.OrdinalIgnoreCase) == 0);
        }

        [Test]
        [Category("RadioButtons")]
        [Retry(2)]
        public void ToggleYes()
        {
            _homePage.GoToTogglesPage();

            var radioButton = _driver.FindElement(By.XPath("//label[contains(text(), 'Select any one')]/ancestor::*//input[@id='yes']"));
            radioButton.Click();    
            
            Assert.That(radioButton.Selected, Is.True); 
        }

        [Test]
        [Category("RadioButtons")]
        [Retry(2)]
        public void RadioDisabled()
        {
            _homePage.GoToTogglesPage();

            var disabledRadio = _driver.FindElement(By.XPath("//label[contains(text(), 'Confirm last field is disabled')]/ancestor::*//input[@id='maybe']"));
            
            Assert.That(disabledRadio.Enabled, Is.False);
        }

        [TearDown]
        public void TearDownTest()
        {
            LogTestDetails(_driver);
            _driver.Close();
        }
    }
}