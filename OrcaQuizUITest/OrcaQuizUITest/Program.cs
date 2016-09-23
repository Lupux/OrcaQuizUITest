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
        private static string username = "admin@quiz.com";
        private static string password = "P@ssw0rd";

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
            Console.WriteLine("Testing Dashboard");
            testUrl = url + @"Dashboard/Index";
            Assert.That(AccessTest(testUrl), Does.Contain(expectedUrl));

            // Manage User, Pass
            Console.WriteLine("Testing ManageUsers");
            testUrl = url + @"ManageUsers/Index";
            Assert.That(AccessTest(testUrl), Does.Contain(expectedUrl));

            // Manage Group, Pass
            Console.WriteLine("Testing ManageGroups");
            testUrl = url + @"ManageGroups/Index";
            Assert.That(AccessTest(testUrl), Does.Contain(expectedUrl));

            // Create test, Pass
            Console.WriteLine("Testing Create Test");
            testUrl = url + @"Admin/Test/Create";
            Assert.That(AccessTest(testUrl), Does.Contain(expectedUrl));

            //Register, Fail
            Console.WriteLine("Testing Register");
            testUrl = url + @"Account/Register";
            Assert.That(AccessTest(testUrl), Does.Not.Contain(expectedUrl));

            // TestSession, Pass
            Console.WriteLine("Testing Testsession");
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

            Console.WriteLine("From Startpage test register button center screen");
            var register = start.TestRegisterCenterBtn();
            expectedUrl = @"Account/Register";
            Assert.That( PropertiesCollection.driver.Url, Does.Contain(expectedUrl)); // Verify Register page
            Console.WriteLine("Result URL: "+PropertiesCollection.driver.Url);

            Console.WriteLine("Testing Homebutton OrcaQuiz logo top left");
            start = register.TestHomeButton();
            expectedUrl = url;
            Assert.That(PropertiesCollection.driver.Url, Does.Contain(expectedUrl)); // Verify Start page
            Console.WriteLine("Result URL: " + PropertiesCollection.driver.Url);

            Console.WriteLine("Testing sign in button Startpage center screen");
            var login = start.TestSignInCenterBtn();
            expectedUrl = @"Account/Login";
            Assert.That(PropertiesCollection.driver.Url, Does.Contain(expectedUrl)); // Verify Sign/Log in page
            Console.WriteLine("Result URL: " + PropertiesCollection.driver.Url);

            Console.WriteLine("Testing Register button in navbar");
            register = login.TestRegisterNavBarLink();
            expectedUrl = @"Account/Register";
            Assert.That(PropertiesCollection.driver.Url, Does.Contain(expectedUrl)); // Verify Register page
            Console.WriteLine("Result URL: " + PropertiesCollection.driver.Url);

            Console.WriteLine("Testing Sign in button in navbar");
            login = register.TestSignInNavBarLink();
            expectedUrl = @"Account/Login";
            Assert.That(PropertiesCollection.driver.Url, Does.Contain(expectedUrl)); // Verify Sign/Log in page
            Console.WriteLine("Result URL: " + PropertiesCollection.driver.Url);

            Console.WriteLine("Test Ended");
        }

        [Test]
        public void LoginTest()
        {
            Console.WriteLine("Running LoginTest Test!");
            string LoginUrl = "http://localhost:27015/Account/Login";
            PropertiesCollection.driver.Manage().Window.Maximize();
            PropertiesCollection.driver.Navigate().GoToUrl(LoginUrl);
            Console.WriteLine(PropertiesCollection.driver.Url);

            SignInPageObject pageLogin = new SignInPageObject();

            // Test With no value
            Console.WriteLine("Test to sign in with empty text boxes");
            var dashboard = pageLogin.Signin(String.Empty, String.Empty);
            Assert.That(dashboard.FindIsHome, Is.False);
            Console.WriteLine("Sign in failed with empty, empty. Test Pased");

            // Test with only username
            Console.WriteLine("Test to sign in with only username");
            dashboard = pageLogin.Signin(username, String.Empty);
            Assert.That(dashboard.FindIsHome, Is.False);
            Console.WriteLine("Sign in failed with Username, empty. Test Pased");

            // Clear textboxes
            pageLogin.ClearTextBoxes();

            // Test With inCorrect Values
            Console.WriteLine("Test to sign in with Faulty values");
            dashboard = pageLogin.Signin("Bartolomeus@ludd.luth.se", "Bitter&Kr3nkt");
            Assert.That(dashboard.FindIsHome, Is.False);
            Console.WriteLine(PropertiesCollection.driver.Url);
            Console.WriteLine("Sign in failed with Faulty valuse. Test Pased");

            // Clear textboxes
            pageLogin.ClearTextBoxes();

            // Test With Correct Values
            Console.WriteLine("Test to sign in with Correct Values");
            dashboard = pageLogin.Signin(username, password);
            Assert.That(dashboard.FindIsHome, Is.True);
            Console.WriteLine(PropertiesCollection.driver.Url);
            Console.WriteLine("Sign in succeeded");

            Console.WriteLine("Test Ended");
        }

        [Test]
        public void GroupsTest()
        {
            Console.WriteLine("Running GroupsTest");
            // Login and prepare for test. 
            var dashboard = LogInPreTest();
            // Set up Valus for test
            string grpname= "Our first test group";
            string admin = "admin@admin.com";
            string newUsers = username + ", "+admin;


            // Get to ManageGroups
            Console.WriteLine("Go to Manage group page from Dashboard");
            ManageGroupsPageObject manageGroups = (ManageGroupsPageObject)dashboard.DDLmenue(AdminChoiseType.Group);
            Console.WriteLine(PropertiesCollection.driver.Url);

            // Verify there are groups
            Console.WriteLine("verify that there are groups");
            Assert.That(manageGroups.ThereAreGroups(), Is.False);

            // Edit Group With pre deifined groupname
            Console.WriteLine("Press edit on " + grpname + " edit button");
            var editGroup = manageGroups.EditGroup(grpname);
            Console.WriteLine(PropertiesCollection.driver.Url);


            // Check if user is part of group. if so remove user.  
            Console.WriteLine("Check if user is part of group, if so remove from group");
            if (editGroup.IsgroupMember(username))
                editGroup = editGroup.RemoveUser(username);
            // Add users to group
            Console.WriteLine("Test to add two users " + newUsers);
            manageGroups = editGroup.AddUsers(newUsers);

            // Pushed to index.
            Console.WriteLine("Return to edit page");
            editGroup = manageGroups.EditGroup(grpname);

            // Test that Users is added.
            Console.WriteLine("Check that new users are added");
            Assert.That(editGroup.IsgroupMember(username), Is.True);
            Assert.That(editGroup.IsgroupMember(admin), Is.True);

            // remove user admin@admin.com
            Console.WriteLine("Remove "+ admin);
            editGroup = editGroup.RemoveUser(admin);

            // Verify that that admin is removed.
            Console.WriteLine("Test That admin@admin is removed");
            Assert.That(editGroup.IsgroupMember(admin), Is.False);

            Console.WriteLine("Back to index");
            manageGroups = editGroup.BottomGoBack();

            // Go to dashboard by Home button
            Console.WriteLine("Go To Dashboard");
            dashboard = manageGroups.TestHomeButton(); // Not working/unstable problem clicking element.

            // verify that user is part of group. 
            Console.WriteLine("Verify that user is part of group on dashboard");
            Assert.That(dashboard.IsGroupMember(grpname));


            Console.WriteLine("Groups Test Done.");
        }

        [Test]
        public void UserTests()
        {
            Console.WriteLine("Running UserTests");
            // Login and prepare for test. 
            var dashboard = LogInPreTest();

            // Get to Manage Users
            Console.WriteLine("Goto ManageUser page");
            ManageUserPageObject manageUsers = (ManageUserPageObject)dashboard.DDLmenue(AdminChoiseType.Users);
            
            // Search admin
            Console.WriteLine("Searching for admin");
            manageUsers = manageUsers.TestSearch("admin");

            /*Test Search function:
             * Expected to find self and admin@admin.com
             * Go to ViewUser page of self
             */
            Console.WriteLine("Find username and go to username page");
            ViewUserPageObject viewUser = manageUsers.GetUserPage(username);
            Console.WriteLine(PropertiesCollection.driver.Url);

            /* Check if current user is same as loged in:
             *   Expected to be true and to find text displayed that can not change status of yourself.
             *   This is only visable if self.
             */
            Console.WriteLine("Assert that user is username and can not change own status");
            Assert.That(viewUser.CheckSelf(), Is.True);

            // Go back to ManageUser page
            Console.WriteLine("Go back to search site expect to find values form last search");
            manageUsers = viewUser.GoBack();
            Console.WriteLine(PropertiesCollection.driver.Url);

            /* Test Make and revoke admin previliges
             *Go to admin@admin.com page and check if admin.
             * if admin change to not admin and then change back 
             * else change to admin then revoke
             */
            Console.WriteLine("Go to admin@admin page");
            viewUser = manageUsers.GetUserPage("admin@admin.com");
            Console.WriteLine(PropertiesCollection.driver.Url);

            Console.WriteLine("Check for admin status");
            bool IsAdmin = viewUser.CheckIsAdmin();

            if (IsAdmin)
            {
                Console.WriteLine("Is Admin. Test to revoke then make admin status");
                viewUser.ChangeStatus();
                Assert.That(viewUser.CheckIsAdmin(), Is.False);
                viewUser.ChangeStatus();
                Assert.That(viewUser.CheckIsAdmin(), Is.True);
            }
            else
            {
                Console.WriteLine("Is not admin, make then revoke status");
                viewUser.ChangeStatus();
                Assert.That(viewUser.CheckIsAdmin(), Is.True);
                viewUser.ChangeStatus();
                Assert.That(viewUser.CheckIsAdmin(), Is.False);
            }

            // Return back to ManageUser Page
            manageUsers = viewUser.GoBack();

            Console.WriteLine("User Test Done.");

        }

        private DashboardPageObject LogInPreTest()
        {
            Console.WriteLine("Running Login Sequence");

            string LoginUrl = "http://localhost:27015/Account/Login";
            PropertiesCollection.driver.Manage().Window.Maximize();
            PropertiesCollection.driver.Navigate().GoToUrl(LoginUrl);
            Console.WriteLine(PropertiesCollection.driver.Url);

            SignInPageObject pageLogin = new SignInPageObject();
            var dashboard = pageLogin.Signin(username, password);
            Assert.That(dashboard.FindIsHome);
            Console.WriteLine(PropertiesCollection.driver.Url);
            Console.WriteLine("Login Sequence finished");

            return dashboard;

        }

        [TearDown]
        public void CleanUp()
        {
            PropertiesCollection.driver.Close();
            Console.WriteLine("Cleaning up after test run");
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
