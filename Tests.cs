using SeleniumC_.Pages;
using SeleniumC_.Helpers;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace SeleniumC_
{
    [TestFixture]
    public class Tests : TestBase
    {

        [Test,Order(2)]
        public void GoToSignIn()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.GoToLoginPage();
            LogTestStep(_context.Test.Name, Status.Pass, "Navigated to login page successfully");
        }

        [Test,Order(3)]
        public void Login()
        {
            LoginPage page = new LoginPage(_driver);

            page.EnterCredentials("Jack99@testing.com", "Test123!");
            LogTestStep(_context.Test.Name, Status.Pass, "Entered login credentials successfully");
            page.ClickLogin();
            LogTestStep(_context.Test.Name, Status.Pass, "Login button clicked!");
        }

        [Test, Order(1)]
        public void SelectDropdownOption()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.GoToDropDownPage();
            LogTestStep(_context.Test.Name, Status.Pass, "Navigated to dropdown page successfully");

            By dropdownLocator = By.CssSelector("[id='fruits']");

            SeleniumHelpers.SelectDropDownValue(_driver, dropdownLocator, "Apple", "text");

            Assert.That(SeleniumHelpers.IsVisible(_driver.FindElement(dropdownLocator)) == true);
            LogTestStep(_context.Test.Name, Status.Pass, "Selected Apple from dropdown");
        }
    }
}