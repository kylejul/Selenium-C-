using OpenQA.Selenium;
using SeleniumC_.Interfaces;
using SeleniumExtras.PageObjects;

namespace SeleniumC_.Pages
{
    public class HomePage : IPage
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

        [FindsBy(How = How.CssSelector, Using = "[href='/button']")]
        private IWebElement Buttons;

        [FindsBy(How = How.CssSelector, Using = "[href='/radio']")]
        private IWebElement Toggles;

        [FindsBy(How = How.CssSelector, Using = "[href='/alert']")]
        private IWebElement Alerts;


        public void GoToLoginPage()
        {
            _driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
        }

        public void GoToDropDownPage()
        {
            dropDowns.Click();
        }

        public string GetText(By locator)
        {
            return _driver.FindElement(locator).Text;
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
