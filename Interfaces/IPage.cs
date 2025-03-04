using OpenQA.Selenium;

namespace SeleniumC_.Interfaces
{
    internal interface IPage
    {
        string GetText(By locator);
    }
}
