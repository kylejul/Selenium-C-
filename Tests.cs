using OpenQA.Selenium;
using SeleniumC_.Pages;

namespace SeleniumC_
{
    public class Tests : TestBase
    {

        [Test,Order(1)]
        public void GoToSignIn()
        {
            _driver.Navigate().GoToUrl("https://letcode.in/test");
            _driver.Manage().Window.Maximize();
            var signInButton = _driver.FindElement(By.CssSelector("[href='/signin']"));
            signInButton.Click();
        }

        [Test,Order(2)]
        public void LoginTest()
        {
            LoginPage page = new LoginPage(_driver);

            page.EnterCredentials("Jack99@testing.com", "Test123!");
            page.ClickLogin();
        }
    }
}