using SeleniumC_.Pages;
using SeleniumC_.Helpers;
using OpenQA.Selenium;

namespace SeleniumC_
{
    public class Tests : TestBase
    {

        [Test,Order(2)]
        public void GoToSignIn()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.GoToLoginPage();
        }

        [Test,Order(3)]
        public void Login()
        {
            LoginPage page = new LoginPage(_driver);

            page.EnterCredentials("Jack99@testing.com", "Test123!");
            page.ClickLogin();
        }

        [Test, Order(1)]
        public void SelectDropdownOption()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.GoToDropDownPage();

            By dropdownLocator = By.CssSelector("[id='fruits']");

            SeleniumHelpers.SelectDropDownValue(_driver, dropdownLocator, "Apple", "text");

            Assert.That(SeleniumHelpers.IsVisible(_driver.FindElement(dropdownLocator)) == true);
        }
    }
}