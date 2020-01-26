using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GE2AutomatedTesting.Support
{
    public static class ScreenShot
    {
        public static void TakeScreenShot(string title = null)
        {
            Screenshot ss = ((ITakesScreenshot)Driver.Session).GetScreenshot();
            if (title == null)
                title = ScenarioContext.Current.ScenarioInfo.Title;
            string Runname = title + DateTime.Now.ToString("_yyyy-MM-dd-HH_mm_ss");
            string screenshotfilename = Runname + ".jpg";            
            ss.SaveAsFile(Config.ScreenShotPath+screenshotfilename, ScreenshotImageFormat.Jpeg);
        }
    }
}
