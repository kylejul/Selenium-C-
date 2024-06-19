using OpenQA.Selenium;
using SeleniumC_.Helpers;
using SeleniumExtras.PageObjects;

namespace SeleniumC_.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement emailField;


        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement passwordField;


        [FindsBy(How = How.XPath, Using = "(//button[@class='button is-primary'])[1]")]
        private IWebElement loginButton;


        [FindsBy(How = How.Id, Using = "toast-container")]
        public IWebElement loginErrorMessage;



        public void EnterCredentials(string email, string password)
        {
            SeleniumHelpers.WaitForDOMToLoad(_driver);

            emailField.SendKeys(email);
            passwordField.SendKeys(password);
        }

        public void ClickLogin()
        {
            SeleniumHelpers.WaitToBeClickable(_driver, loginButton);
            loginButton.Click();
        }
    }
}
