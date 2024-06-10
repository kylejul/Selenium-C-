using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumC_
{
    public class Tests
    {
        public IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            var driverPath = Environment.GetEnvironmentVariable("ChromeDriverPath");
            _driver = new ChromeDriver(driverPath);
        }

        [Test]
        public void Test1()
        {
            _driver.Navigate().GoToUrl("https://webdriveruniversity.com/index.html");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}