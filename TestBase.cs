using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;

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
            var path = Directory.CreateDirectory(dir + "/eReport/").ToString();
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path);

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
        }

        public static void StartExtentTest(string test)
        {
            _test = _extentReports.CreateTest(test);
        }

        public static void LogTestDetails()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Skipped:
                    _test.Log(Status.Skip, "Test was skipped");
                    break;
                case TestStatus.Failed:
                    _test.Log(Status.Fail, $"Test failed with  {errorMessage}");
                    break;
                default:
                    _test.Log(Status.Pass, "The test has finished successfully");
                    break;
            }
        }


        public void LogTestStep(string testName, Status status, string testStepMessage)
        {
            _test = _extentReports.CreateTest(testName);
            _test.Log(status, testStepMessage);
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _extentReports.Flush();
        }

    }
}
