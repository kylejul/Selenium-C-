using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumC_.Pages
{
    public class LoginPage
    {

        [FindsBy(How = How.Id, Using = "text")]

        public IWebElement usernameField;


        [FindsBy(How = How.Id, Using = "password")]

        public IWebElement passwordField;


        [FindsBy(How = How.Id, Using = "login-button")]

        public IWebElement loginButton;


        public void EnterCredentials(string username, string password)
        {
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
        }

        public void ClickLogin()
        {
            loginButton.Click();
        }
    }
}
