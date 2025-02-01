using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumC_.Helpers;

namespace SeleniumC_.Pages
{
    public class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[href='/signin']")]
        private IWebElement loginButton;

        [FindsBy(How = How.CssSelector, Using = "[href='/dropdowns']")]
        private IWebElement dropDowns;

        [FindsBy(How = How.CssSelector, Using = "[href='/buttons']")]
        private IWebElement Buttons;

        [FindsBy(How = How.CssSelector, Using = "[href='/radio']")]
        private IWebElement Toggles;

        [FindsBy(How = How.CssSelector, Using = "[href='/alert']")]
        private IWebElement Alerts;


        public void GoToLoginPage()
        {
            loginButton.Click();
        }

        public void GoToDropDownPage()
        {
            dropDowns.Click();
        }

        public void GoToButtonsPage()
        {
            Buttons.Click();
        }

        public void GoToTogglesPage()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", Toggles);
        }  
        
        public void GoToAlertsPage()
        {
            Alerts.Click();
        }

    }
}
