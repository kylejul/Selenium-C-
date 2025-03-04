using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SeleniumC_.Utils;

namespace SeleniumC_
{
    public class TestBase
    {
        protected static ExtentTest _test;
        protected static ExtentReports _extentReports;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            string dir = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..");
            string path = Directory.CreateDirectory(dir + "/eReport/").ToString();
            ExtentHtmlReporter htmlReporter = new(path);

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);

            Screenshots.CleanUpScreenShots();
        }

        protected static void StartExtentTest(string test)
        {
            _test = _extentReports.CreateTest(test);
        }

        protected static void LogTestDetails(IWebDriver driver)
        {
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            string errorMessage = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Skipped:
                    _test.Log(Status.Skip, "Test was skipped");
                    break;
                case TestStatus.Failed:
                    if (TestContext.CurrentContext.CurrentRepeatCount == 1)
                    {
                        string screenCapture = Screenshots.Capture(driver, TestContext.CurrentContext.Test.Name);
                        _test.Log(Status.Fail, $"Test failed with  {errorMessage}");
                        _test.Log(Status.Info, "Screenshot: " + _test.AddScreenCaptureFromPath(screenCapture));
                    }
                    else
                    {
                        _extentReports.RemoveTest(_test);
                    }
                    break;
                default:
                    _test.Log(Status.Pass, "The test has finished successfully");
                    break;
            }
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _extentReports.Flush();
        }
    }
}
