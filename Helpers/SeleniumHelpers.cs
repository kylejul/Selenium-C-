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
    }
}
