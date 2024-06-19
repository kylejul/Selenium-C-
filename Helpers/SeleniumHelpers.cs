using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumC_.Helpers
{
    public static class SeleniumHelpers
    {
        public static void WaitToBeClickable(IWebDriver driver, IWebElement element, int waitTimeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static bool IsVisible(IWebElement element)
        {
            bool isVisible = element.Displayed;
            return isVisible;
        }

        public static void WaitToBeVisible(IWebDriver driver, By locator ,int waitTimeout = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeout));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForDOMToLoad(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void SelectDropDownValue(IWebDriver driver, By dropDownLocator, string value, string selectByType)
        {
            SelectElement select = new SelectElement(driver.FindElement(dropDownLocator));

            if (selectByType == "value")
            {
                select.SelectByValue(value);
            }

            else
            {
                select.SelectByText(value);
            }
        }
    }
}
