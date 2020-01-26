using System;
using GE2AutomatedTesting.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace GE2AutomatedTesting.Support
{
    public static class DriverFactory
    {
        public static IWebDriver GetNewDriver(DriverType type)
        {
            DesiredCapabilities dc;
            switch (type)
            {
                case DriverType.Chrome:
                    return new ChromeDriver(Config.ChromeDriverPath);

                case DriverType.Android:
                    var appiumOptions = new AppiumOptions();
                    appiumOptions.AddAdditionalCapability("deviceName", Config.DeviceName);
                    appiumOptions.PlatformName=Config.PlatformName;
                    appiumOptions.AddAdditionalCapability("platformVersion", Config.PlatformVersion);
                    appiumOptions.AddAdditionalCapability("browserName", Config.BrowserName);
                    appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, Config.AppName);
                    appiumOptions.AddAdditionalCapability("newCommandTimeout", "200");
                    return new AndroidDriver<AndroidElement>(appiumOptions);


               case DriverType.SauceLabsRemote:
                    dc = new DesiredCapabilities();
                    dc.SetCapability(CapabilityType.BrowserName, Environment.GetEnvironmentVariable("SELENIUM_BROWSER"));
                    dc.SetCapability(CapabilityType.Version, Environment.GetEnvironmentVariable("SELENIUM_VERSION"));
                    dc.SetCapability(CapabilityType.Platform, Environment.GetEnvironmentVariable("SELENIUM_PLATFORM"));
                    dc.SetCapability("username", Environment.GetEnvironmentVariable("SAUCE_USERNAME"));
                    dc.SetCapability("accessKey", Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY"));
                    dc.SetCapability("name", ScenarioContext.Current.ScenarioInfo.Title);
                    return new RemoteWebDriver(
                        new Uri("http://" + Environment.GetEnvironmentVariable("SAUCE_USERNAME") + ":" + Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY") + "@ondemand.saucelabs.com:80/wd/hub"), 
                        dc, 
                        TimeSpan.FromSeconds(600));

                default:
                    return new FirefoxDriver();
            }
        }
    }
}
