using OpenQA.Selenium;
using SeleniumC_.Interfaces;
using SeleniumExtras.PageObjects;
using SeleniumC_.Helpers;

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

        [FindsBy(How = How.CssSelector, Using = "[href='/selectable']")]
        private IWebElement MultiSelect;
        
        [FindsBy(How = How.CssSelector, Using = "[href='/calendar']")]
        private IWebElement Calendar;

        [FindsBy(How = How.CssSelector, Using = "[href='/dropdowns']")]
        private IWebElement DropDowns;

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
            DropDowns.Click();
        } 
        
        public void GoToMultiSelectPage()
        {
            SeleniumHelpers.Click(_driver, MultiSelect);
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
            SeleniumHelpers.Click(_driver, Toggles);
        }  
        
        public void GoToAlertsPage()
        {
            Alerts.Click();
        } 
        
        public void GoToCalendarPage()
        {
            SeleniumHelpers.Click(_driver, Calendar);
        }
    }
}
