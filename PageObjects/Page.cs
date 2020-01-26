using GE2AutomatedTesting.Support;
using OpenQA.Selenium;

namespace GE2AutomatedTesting.PageObjects
{
    abstract public class Page
    {
        public abstract void Go();

        public abstract bool IsPageLoaded();
        
    }
}
