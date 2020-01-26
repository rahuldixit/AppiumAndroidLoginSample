using GE2AutomatedTesting.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace GE2AutomatedTesting.UnitTests
{
    [TestClass]
    public class Tests
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [DataSource(@"System.Data.Odbc", @"Dsn=Excel Files;dbq=TestData.xlsx;defaultdir=C:\Users\Rahul\source\repos\CSharpSeleniumFramework\TestData\; driverid=790;maxbuffersize=2048;pagetimeout=5", "Login$", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Test1()
        {
            Hooks.BeforeDataDrivenTest();
            StepDefinitions.LoginSteps.GivenILoginAsUserWithPassword(TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());
            Hooks.AfterDataDrivenTest(TestContext.TestName);
        }
    }
}
