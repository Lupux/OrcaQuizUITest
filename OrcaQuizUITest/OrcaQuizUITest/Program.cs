using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OrcaQuizUITest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcaQuizUITest
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        [SetUp]
        public void Initialize()
        {
            //Local version URL:
            string url = "http://localhost:27015/";

            PropertiesCollection.driver = new ChromeDriver(@"C:\Projects\OrcaQuizUITest\OrcaQuizUITest\OrcaQuizUITest\");

            // Navigate to startPage
            PropertiesCollection.driver.Navigate().GoToUrl(url);
            Console.WriteLine("Init test");
        }

        [Test]
        public void AccessTests()
        {
            Console.WriteLine("Running access test ");
           /* Arrange */
            string url = "http://localhost:27015/";
            string testUrl;
            string expectedUrl = "http://localhost:27015/Account/Login";

            
            // Dashboard, Pass
            testUrl = url + @"Dashboard/Index"; 
            Assert.That( AccessTest(testUrl), Does.Contain(expectedUrl)); 

            // Manage User, Pass
            testUrl = url + @"ManageUsers/Index";
            Assert.That(AccessTest(testUrl), Does.Contain(expectedUrl));

            // Manage Group, Pass
            testUrl = url + @"ManageGroups/Index";
            Assert.That(AccessTest(testUrl), Does.Contain(expectedUrl));

            // Create test, Pass
            testUrl = url + @"Admin/Test/Create";
            Assert.That(AccessTest(testUrl), Does.Contain(expectedUrl));

            //Register, Fail
            testUrl = url + @"Account/Register";
            Assert.That(AccessTest(testUrl), Does.Not.Contain(expectedUrl));

            // TestSession, Pass
            testUrl = url + @"TestSession/7013/1";
            Assert.That(AccessTest(testUrl), Does.Contain(expectedUrl));


        }


        [Test]
        public void TestLinksForNotSignedIn()
        {
            Console.WriteLine("Running TestLinksForNotSignedIn Test!");
            /* Arrange */
            string url = "http://localhost:27015/";
            //string testUrl;
            string expectedUrl = "http://localhost:27015/Account/Login";

            // go to start page
            StartPageObject start = new StartPageObject();
            expectedUrl = url;
            Assert.That(PropertiesCollection.driver.Url, Does.Contain(expectedUrl)); // Verify Start page
            Console.WriteLine(PropertiesCollection.driver.Url);

            /* Test Links for not signed in user*/
            // Not Yet Functional
            var register=start.TestRegisterCenterBtn();
            expectedUrl = @"Account/Register";
            Assert.That(PropertiesCollection.driver.Url, Does.Contain(expectedUrl)); // Verify Register page
            Console.WriteLine(PropertiesCollection.driver.Url);

            start = register.TestHomeButton();
            expectedUrl = url;
            Assert.That(PropertiesCollection.driver.Url, Does.Contain(expectedUrl)); // Verify Start page
            Console.WriteLine(PropertiesCollection.driver.Url);

            var login = start.TestSignInCenterBtn();
            expectedUrl = @"Account/Login";
            Assert.That(PropertiesCollection.driver.Url, Does.Contain(expectedUrl)); // Verify Sign/Log in page
            Console.WriteLine(PropertiesCollection.driver.Url);

            register = login.TestRegisterNavBarLink();
            expectedUrl = @"Account/Register";
            Assert.That(PropertiesCollection.driver.Url, Does.Contain(expectedUrl)); // Verify Register page
            Console.WriteLine(PropertiesCollection.driver.Url);

            login = register.TestSignInNavBarLink();
            expectedUrl = @"Account/Login";
            Assert.That(PropertiesCollection.driver.Url, Does.Contain(expectedUrl)); // Verify Sign/Log in page
            Console.WriteLine(PropertiesCollection.driver.Url);

            Console.WriteLine("Test Ended");
        }

        [Test]
        public void LoginTest()
        {
            Console.WriteLine("Running LoginTest Test!");
            string username = "admin@quiz.com";
            string password = "P@ssw0rd";
           // string url = "http://localhost:27015/";
            string LoginUrl = "http://localhost:27015/Account/Login";
            PropertiesCollection.driver.Manage().Window.Maximize();
            PropertiesCollection.driver.Navigate().GoToUrl(LoginUrl);
            Console.WriteLine(PropertiesCollection.driver.Url);

            SignInPageObject pageLogin = new SignInPageObject();

            var dashboard =  pageLogin.Signin(username, password);
            
            Console.WriteLine(PropertiesCollection.driver.Url);
            Assert.That(dashboard.FindCreateTestBtn);
            Console.WriteLine(PropertiesCollection.driver.Url);

            Console.WriteLine("Test Ended");
        }


        [TearDown]
        public void CleanUp()
        {
            PropertiesCollection.driver.Close();
            Console.WriteLine("Closing Test");
        }

        public string AccessTest(string testUrl)
        {
            string currentURL;
            PropertiesCollection.driver.Navigate().GoToUrl(testUrl);
            PropertiesCollection.driver.Manage().Window.Maximize();
            currentURL = PropertiesCollection.driver.Url;
           
            Console.WriteLine($" current Url is {currentURL}");
            return currentURL;
        }
    }
}
