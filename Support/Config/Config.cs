using System.Configuration;
using GE2AutomatedTesting.Enums;

namespace GE2AutomatedTesting.Support
{
    public class Config
    {
        public static string AppName
        {
            get { return ConfigurationManager.AppSettings["AppName"]; }
        }

        public static string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["BaseUrl"]; }
        }

        public static DriverType DriverType
        {
            get { return Tools.ParseEnum<DriverType>(ConfigurationManager.AppSettings["DriverType"]); }
        }

        public static string ChromeDriverPath
        {
            get { return ConfigurationManager.AppSettings["ChromeDriverPath"]; }
        }

        public static string DeviceName
        {
            get { return ConfigurationManager.AppSettings["DeviceName"]; }
        }

        public static string PlatformName
        {
            get { return ConfigurationManager.AppSettings["PlatformName"]; }
        }

        public static string PlatformVersion
        {
            get { return ConfigurationManager.AppSettings["PlatformVersion"]; }
        }

        public static string BrowserName
        {
            get { return ConfigurationManager.AppSettings["BrowserName"]; }
        }

       

        public static string LogPath
        {
            get { return ConfigurationManager.AppSettings["LogPath"]; }
        }

        public static string ReportPath
        {
            get { return ConfigurationManager.AppSettings["ReportPath"]; }
        }

        public static string ScreenShotPath
        {
            get { return ConfigurationManager.AppSettings["ScreenShotPath"]; }
        }

        public static string ExcelData
        {
            get { return ConfigurationManager.AppSettings["ExcelData"]; }
        }
    }
}
