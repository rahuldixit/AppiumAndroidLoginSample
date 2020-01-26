using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GE2AutomatedTesting.Support
{
    public static class SeleniumKeywords
    {
        public static void Navigate(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            Hooks.LogMsg.Info("Navigating to: " + url);
            Hooks.test.Log(Status.Pass, "Navigating to: " + url);
        }

        public static void SetText(this IWebElement element, string text)
        {
           
                element.Clear();
                element.SendKeys(text);
            Hooks.LogMsg.Info("Setting text on: " + element.ToString() + " to: " + text);
        }

        public static string GetText(this IWebElement element)
        {
            return element.Text;
        }

        public static string GetValue(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static void ScrollMobile(IPerformsTouchActions driver, IWebElement element)
        {
            TouchAction touchAction = new TouchAction(driver);

            touchAction
                .MoveTo(element,0,0)
                .Perform();           
        }

        public static void Click(this IWebElement element)
        {
            element.Click();
        }

        public static bool WaitForDisplayed(this IWebDriver driver, By element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until((d)=>d.FindElement(element).Displayed);
            return driver.FindElement(element).Displayed;
        }

        public static void WaitForText(this IWebDriver driver, By element, string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until((d) => d.FindElement(element).GetValue() == text);
        }
    }
}
