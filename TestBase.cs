using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumC_
{
    public class TestBase
    {
        protected IWebDriver _driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var driverPath = Environment.GetEnvironmentVariable("ChromeDriverPath");
            _driver = new ChromeDriver(driverPath);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}
