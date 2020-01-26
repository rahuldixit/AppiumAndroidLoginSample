using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace GE2AutomatedTesting.Support
{
    public static class SeleniumExtensions
    {
        

        public static void DragAndDrop(this IWebDriver driver, By sourceSelector, By targetSelector)
        {
            var actions = new Actions(driver);

            var source = driver.FindElement(sourceSelector);
            var target = driver.FindElement(targetSelector);

            actions.DragAndDrop(source, target).Build().Perform();
        }

        public static void DragAndDropToOffset(this IWebDriver driver, By sourceSelector, int x, int y)
        {
            var actions = new Actions(driver);

            var element = driver.FindElement(sourceSelector);

            actions.DragAndDropToOffset(element, x, y).Build().Perform();
        }

        public static  void Execute (this IWebDriver driver, string script)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }
    }
}
