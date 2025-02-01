using OpenQA.Selenium;

namespace SeleniumC_.Utils
{
    public class Screenshots
    {
        /// <summary>
        /// Takes a screenshot of the webpage
        /// </summary>
        /// <param name="driver">Webdriver instance</param>
        /// <param name="screenShotName">Description of the screenshot</param>
        /// <returns>Path to the saved screenshot</returns>
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

        /// <summary>
        /// Deletes all saved screenshots
        /// </summary>
        public static void CleanUpScreenShots()
        {
            string screenShotsPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\../screenshots");

            if (!Directory.Exists(screenShotsPath)) return;

            Directory.Delete(screenShotsPath, true);
        }
    }
}
