using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

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


        public void GoToLoginPage()
        {
            loginButton.Click();
        }

        public void GoToDropDownPage()
        {
            dropDowns.Click();
        }
    }
}
