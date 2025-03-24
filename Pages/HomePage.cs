using OpenQA.Selenium;
using SeleniumC_.Helpers;
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

        [FindsBy(How = How.CssSelector, Using = "[href='/selectable']")]
        private IWebElement MultiSelect;

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
           ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", MultiSelect);
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
