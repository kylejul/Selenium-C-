using OpenQA.Selenium;

namespace SeleniumC_.Utils
{
    public class Screenshots
    {
        public static string Capture(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();

            string dir = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..");
            string path = Directory.CreateDirectory(dir + "/screenshots/").ToString();

            string screenShotPath = path + screenShotName + ".png";

            screenshot.SaveAsFile(screenShotPath);

            string relativePath = "../screenshots/" + screenShotName + ".png";

            return relativePath;
        }

        public static void CleanUpScreenShots()
        {
            string screenShotsPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\../screenshots");
            Directory.Delete(screenShotsPath, true);
        }
    }
}
