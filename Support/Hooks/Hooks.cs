using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NetLogger;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace GE2AutomatedTesting.Support
{
    [Binding]
    public sealed class Hooks
    {
        public static ExtentReports extent = new ExtentReports();
        public static ExtentTest test; 
        public static ExtentTest feature;
        public static ExtentTest scenario;
        public static ExtentHtmlReporter reporter = new ExtentHtmlReporter(Config.ReportPath+ DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss") + "_Report.html");
        public static Log LogMsg = new Log(Config.LogPath, DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss")+"_Log.txt");
        
        public static void BeforeDataDrivenTest()
        {
            Driver.Session = DriverFactory.GetNewDriver(Config.DriverType);
            //Driver.Session.Manage().Window.Maximize();
            //Driver.Session.Navigate().GoToUrl(Config.BaseUrl);
        }

        public static void AfterDataDrivenTest(string testName)
        {
            ScreenShot.TakeScreenShot(testName);
            Driver.Session.Quit();
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            ExcelData.ReadData();            
            extent.AttachReporter(reporter);
            reporter.LoadConfig("extent-config.xml");
            test = extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
            feature = test.CreateNode<Feature>(FeatureContext.Current.FeatureInfo.Title);
            scenario = feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionEventHandler;

            LogMsg.Info("Starting Test Case: "+ScenarioContext.Current.ScenarioInfo.Title);
            
            Driver.Session = DriverFactory.GetNewDriver(Config.DriverType);
            //Driver.Session.Manage().Window.Maximize();
            //Driver.Session.Navigate().GoToUrl(Config.BaseUrl);
        }

        [AfterStep]
        public void AfterEveryStep(ScenarioContext scenarioContext)
        {
            var stepInfo = scenarioContext.StepContext.StepInfo;
            var stepType = stepInfo.StepInstance.StepDefinitionType.ToString();

            ExtentTest stepNode = null;
            switch (stepType)
            {
                case "Given":
                    stepNode = scenario.CreateNode(stepInfo.Text);
                    break;
                case "When":
                    stepNode = scenario.CreateNode(stepInfo.Text);
                    break;
                case "Then":
                    stepNode = scenario.CreateNode(stepInfo.Text);
                    break;
            }

            if (scenarioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
            {
                Screenshot ss = ((ITakesScreenshot)Driver.Session).GetScreenshot();
                string screenshot = ss.AsBase64EncodedString;

                List<ScenarioExecutionStatus> failTypes = new List<ScenarioExecutionStatus>
                {
                ScenarioExecutionStatus.BindingError,
                ScenarioExecutionStatus.TestError,
                ScenarioExecutionStatus.UndefinedStep
                };

                if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.StepDefinitionPending)
                {
                    stepNode.Skip("This step has been skipped and not executed.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build());
                }
                else if (failTypes.Contains(scenarioContext.ScenarioExecutionStatus))
                {
                    test.Fail("Test Failed");
                    stepNode.Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build());
                }
            }
        }

        
        [AfterScenario]
        public static void AfterScenario()
        {
            if (test.Status == Status.Pass)
                test.Pass(ScenarioContext.Current.ScenarioInfo.Title + " has passed!");
            else
                test.Fail("!");
            extent.Flush();
            ScreenShot.TakeScreenShot();
            Driver.Session.Quit();
        }

        private static void UnhandledExceptionEventHandler(object sender, System.UnhandledExceptionEventArgs eventArgs)
        {
            test.Fail(eventArgs.ExceptionObject.ToString());
            LogMsg.Error(eventArgs.ExceptionObject.ToString());
            extent.Flush();
            ScreenShot.TakeScreenShot();
            Driver.Session.Quit();
        }
    }
}
