using GE2AutomatedTesting.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Interactions;

namespace GE2AutomatedTesting.PageObjects
{
    public class LoginPage : Page
    {
        private readonly By _emailSelector =  MobileBy.Id("com.loginmodule.learning:id/textInputEditTextEmail");
        private readonly By _pwdSelector = MobileBy.Id("com.loginmodule.learning:id/textInputEditTextPassword");
        private readonly By _loginBtnSelector = MobileBy.Id("com.loginmodule.learning:id/appCompatButtonLogin");
        private readonly By _createLoginBtnSelector = MobileBy.Id("com.loginmodule.learning:id/textViewLinkRegister");

        
        public override void Go()
        {
            IsPageLoaded();
        }

        public override bool IsPageLoaded()
        {
            return Driver.Session.FindElement(_emailSelector).Displayed;            
        }

        public void CreateLogin()
        {
            var element = Driver.Session.FindElement(_createLoginBtnSelector);
            element.Click();           
        }

        public void SetEmail(string email)
        {
            var element = Driver.Session.FindElement(_emailSelector);
            element.SetText(email);
            ((AndroidDriver<AndroidElement>) Driver.Session).PressKeyCode(AndroidKeyCode.Enter);
        }

        public void SetPassword(string pwd)
        {
            var element = Driver.Session.FindElement(_pwdSelector);
            element.SetText(pwd);
            ((AndroidDriver<AndroidElement>)Driver.Session).PressKeyCode(AndroidKeyCode.Enter);
        }

        public void ClickLogin()
        {
            ((AndroidDriver<AndroidElement>)Driver.Session).HideKeyboard();
            var element = Driver.Session.FindElement(_loginBtnSelector);
            element.Click();
            
       }
    }
}
