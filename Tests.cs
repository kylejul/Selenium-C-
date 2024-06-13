using OpenQA.Selenium;
using SeleniumC_.Helpers;
using SeleniumC_.Pages;

namespace SeleniumC_
{
    public class Tests : TestBase
    {

        [Test,Order(1)]
        public void GoToLoginPortal()
        {
            _driver.Navigate().GoToUrl("https://webdriveruniversity.com/index.html");
            var loginPortal = _driver.FindElement(By.Id("login-portal"));
            loginPortal.Click();
        }

        [Test,Order(2)]
        public void LoginTest()
        {
            var page = new LoginPage();

            page.EnterCredentials("Jack99", "Test123!");

            SeleniumHelpers.WaitToBeClickable(_driver, page.loginButton);
            page.ClickLogin();
        }
    }
}