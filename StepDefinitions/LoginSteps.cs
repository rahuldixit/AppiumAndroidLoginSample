using GE2AutomatedTesting.PageObjects;
using GE2AutomatedTesting.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace GE2AutomatedTesting.StepDefinitions
{
    [Binding]
    public static class LoginSteps
    {
        [Given(@"I login as user ""(.*)"" with password ""(.*)""")]
        public static void GivenILoginAsUserWithPassword(string usr, string pwd)
        {
            
            var loginPage = new LoginPage();

            loginPage.Go();
            loginPage.CreateLogin();

            var registerPage = new CreateLoginPage();
            registerPage.Go();
            registerPage.RegisterUser(usr, pwd);

            loginPage.SetEmail(usr);
            loginPage.SetPassword(pwd);
            loginPage.ClickLogin();
        }

        [Given(@"I login with valid user credential")]
        public static void GivenILoginWithValidUserCredentials()
        {
            GivenILoginAsUserWithPassword(ExcelData.GetData("Login","Test_1","UserName"), ExcelData.GetData("Login", "Test_1", "Password"));
        }

        [Then(@"I am logged in")]
        public static void ThenIAmLoggedIn()
        {
            Driver.Session.WaitForDisplayed(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.LinearLayout/android.support.v7.widget.LinearLayoutCompat/android.widget.TextView[1]"));
        }
    }
}
