using OpenQA.Selenium;
using SeleniumC_.Helpers;
using SeleniumExtras.PageObjects;

namespace SeleniumC_.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "username")]
        private readonly IWebElement usernameField;


        [FindsBy(How = How.Name, Using = "password")]
        private readonly IWebElement passwordField;


        [FindsBy(How = How.Id, Using = "submit")]
        private readonly IWebElement submitButton;


        public void EnterCredentials(string email, string password)
        {
            SeleniumHelpers.WaitForDOMToLoad(_driver);

            usernameField.SendKeys(email);
            passwordField.SendKeys(password);
        }

        public void ClickSubmit()
        {
            SeleniumHelpers.WaitToBeClickable(_driver, submitButton);
            submitButton.Click();
        }
    }
}
