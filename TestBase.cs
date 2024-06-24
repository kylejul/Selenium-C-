using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumC_
{
    public class TestBase
    {
        protected IWebDriver _driver;
        protected ExtentTest _test;
        protected ExtentReports _extentReports;
        protected TestContext _context;

        [OneTimeSetUp]
        public void Setup()
        {
            var driverPath = Environment.GetEnvironmentVariable("ChromeDriverPath");
            _driver = new ChromeDriver(driverPath);

            _context = TestContext.CurrentContext;

            string dir = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..");
            var path = Directory.CreateDirectory(dir + "/eReport/").ToString();
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path);

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://letcode.in/test");

        }

        public void LogTestStep(string testName, Status status, string testStepMessage)
        {
            _test = _extentReports.CreateTest(testName);
            _test.Log(status, testStepMessage);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _extentReports.Flush();
            _driver.Close();
            
        }

    }
}
