using GE2AutomatedTesting.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Interactions;

namespace GE2AutomatedTesting.PageObjects
{
    public class CreateLoginPage : Page
    {
        private readonly By _nameSelector = MobileBy.Id("com.loginmodule.learning:id/textInputEditTextName");
        private readonly By _emailSelector = MobileBy.Id("com.loginmodule.learning:id/textInputEditTextEmail");
        private readonly By _pwdSelector = MobileBy.Id("com.loginmodule.learning:id/textInputEditTextPassword");
        private readonly By _confirmPwdSelector = MobileBy.Id("com.loginmodule.learning:id/textInputEditTextConfirmPassword");        
        private readonly By _registerBtnSelector = MobileBy.Id("com.loginmodule.learning:id/appCompatButtonRegister");
        private readonly By _loginSelector = MobileBy.Id("com.loginmodule.learning:id/appCompatTextViewLoginLink");


        public override void Go()
        {
            IsPageLoaded();
        }

        public override bool IsPageLoaded()
        {
            return Driver.Session.WaitForDisplayed(_emailSelector);            
        }

        public void RegisterUser(string email, string password)
        {
            var element = Driver.Session.FindElement(_nameSelector);
            element.SetText("Rahul");
            ((AndroidDriver<AndroidElement>)Driver.Session).PressKeyCode(AndroidKeyCode.Enter);


            element = Driver.Session.FindElement(_emailSelector);
            element.SetText(email);
            ((AndroidDriver<AndroidElement>) Driver.Session).PressKeyCode(AndroidKeyCode.Enter);


            element = Driver.Session.FindElement(_pwdSelector);
            element.SetText(password);
            ((AndroidDriver<AndroidElement>)Driver.Session).PressKeyCode(AndroidKeyCode.Enter);

            element = Driver.Session.FindElement(_confirmPwdSelector);
            element.SetText(password);
            ((AndroidDriver<AndroidElement>)Driver.Session).PressKeyCode(AndroidKeyCode.Enter);

            ((AndroidDriver<AndroidElement>)Driver.Session).HideKeyboard();
            Driver.Session.FindElement(_registerBtnSelector).Click();
            ((AndroidDriver<AndroidElement>)Driver.Session).Navigate().Back();
        }


    }
}
