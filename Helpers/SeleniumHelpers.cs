using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumC_.Helpers
{
    public static class SeleniumHelpers
    {
        /// <summary>
        /// Wait for the condition of the element to be in a clickable state
        /// </summary>
        /// <param name="driver">Webdriver instance</param>
        /// <param name="element">The web element</param>
        /// <param name="waitTimeout">Amount of time to wait in seconds</param>
        public static void WaitToBeClickable(IWebDriver driver, IWebElement element, int waitTimeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        /// <summary>
        /// Check if the element is visible on the webpage
        /// </summary>
        /// <param name="element">The web element</param>
        /// <returns>True or False</returns>
        public static bool IsVisible(IWebElement element)
        {
            bool isVisible = element.Displayed;
            return isVisible;
        }

        /// <summary>
        /// Wait for the condition of the element being visible on the webpage
        /// </summary>
        /// <param name="driver">Webdriver instance</param>
        /// <param name="locator">Locator of the web element</param>
        /// <param name="waitTimeout">Amount of time to wait in seconds</param>
        public static void WaitToBeVisible(IWebDriver driver, By locator ,int waitTimeout = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeout));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Wait for the condition of the Document Object Model to load completely
        /// </summary>
        /// <param name="driver">Webdriver instance</param>
        public static void WaitForDOMToLoad(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        /// <summary>
        /// Select a value from a select element 
        /// </summary>
        /// <param name="driver">Webdriver instance</param>
        /// <param name="dropDownLocator">Locator of the select element</param>
        /// <param name="value">Value in the select element dropdown to select</param>
        /// <param name="selectByType">Select by value or text</param>
        public static void SelectDropDownValue(IWebDriver driver, By dropDownLocator, string value, string selectByType = "value")
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
