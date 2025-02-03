using OpenQA.Selenium;

namespace SeleniumC_.Interfaces
{
    internal interface IWebElementInteraction
    {
        void Click(IWebDriver driver, By by);
        void SendKeys(IWebDriver driver, By by, string text);
    }
}
