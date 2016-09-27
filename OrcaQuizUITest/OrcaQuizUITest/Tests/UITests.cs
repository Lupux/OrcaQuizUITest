using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OrcaQuizUITest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcaQuizUITest.Tests
{
    class UITests
    {

        // Static Values for testing
        private static string _username = "uitest@admin.com";
        private static string _password = "P@ssw0rd";
        private static string _admin = "admin@admin.com";
        private static string _adminPassword = "@Dmin123";

        private string _UiTestQuizName;

        [SetUp]
        public void RunBeforEachTest()
        {
            //Local version URL:
            string url = "http://localhost:27015/";

            PropertiesCollection.driver = new ChromeDriver(@"C:\Projects\OrcaQuizUITest\OrcaQuizUITest\OrcaQuizUITest\");

            // Navigate to startPage
            PropertiesCollection.driver.Navigate().GoToUrl(url);
            Console.WriteLine("Init test");
        }

        [TearDown]
        public void RunAfterEachTest()
        {
            PropertiesCollection.driver.Close();
            Console.WriteLine("Cleaning up after test run");
        }

        [Test, Order(1)]
        public void AccessDeniedTests()
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


        [Test, Order(2)]
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
            Assert.That(PropertiesCollection.driver.Url, Does.Contain(expectedUrl)); // Verify Register page
            Console.WriteLine("Result URL: " + PropertiesCollection.driver.Url);

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

        [Test, Order(3)]
        public void LoginTests()
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
            dashboard = pageLogin.Signin(_username, String.Empty);
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
            dashboard = pageLogin.Signin(_admin, _adminPassword);
            Assert.That(dashboard.FindIsHome, Is.True);
            Console.WriteLine(PropertiesCollection.driver.Url);
            Console.WriteLine("Sign in succeeded");

            Console.WriteLine("Test Ended");
        }

        [Test, Order(4)]
        public void CreateUserTest()
        {
            Console.WriteLine("Running CreateUserTest Test!");

            string firstName = "UItestAdmin";
            string lastName = "UItest";
            string email = _username;
            string password = _password;


            // go to start page
            StartPageObject start = new StartPageObject();

            Console.WriteLine("From Startpage test register button center screen");
            var register = start.TestRegisterCenterBtn();

            register.FillRegisterForm(firstName, lastName, email, password, password);
            var dashboard = register.ClickRegisterButton();
            Assert.That(dashboard.FindIsHome, Is.True);


        }

        [Test, Order(5)]
        public void FindUserAndMakeRevokeAdmineRoleTests()
        {
            Console.WriteLine("Running UserTests");
            // Login and prepare for test. 
            var dashboard = LogInPreTest(_admin, _adminPassword);

            // Get to Manage Users
            Console.WriteLine("Goto ManageUser page");
            ManageUserPageObject manageUsers = (ManageUserPageObject)dashboard.DDLmenue(AdminChoiseType.ManageUsers);

            // Search admin
            Console.WriteLine("Searching for admin");
            manageUsers = manageUsers.TestSearch("admin");

            /*Test Search function:
             * Expected to find self and admin@admin.com
             * Go to ViewUser page of self
             */
            Console.WriteLine("Find username and go to username page");
            ViewUserPageObject viewUser = manageUsers.GetUserPage(_admin);
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
            Console.WriteLine("Go to uitest@admin page");
            viewUser = manageUsers.GetUserPage(_username);
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
                Console.WriteLine("Make sure is admin");
                viewUser.ChangeStatus();
                Assert.That(viewUser.CheckIsAdmin(), Is.True);
            }

            // Return back to ManageUser Page
            manageUsers = viewUser.GoBack();

            Console.WriteLine("User Test Done.");

        }

        [Test, Order(6)]
        public void CreateGroupWithAddAndRemoveMembersTest()
        {
            Console.WriteLine("Running GroupsTest");
            // Login and prepare for test. 
            var dashboard = LogInPreTest(_username, _password);
            // Set up Valus for test
            string grpname = "Uitestgrupp";

            string newUsers = _username + ", " + _admin;


            // Get to ManageGroups
            Console.WriteLine("Go to Manage group page from Dashboard");
            ManageGroupsPageObject manageGroups = (ManageGroupsPageObject)dashboard.DDLmenue(AdminChoiseType.ManageGroup);
            Console.WriteLine(PropertiesCollection.driver.Url);

            //// Verify there are groups
            //Console.WriteLine("verify that there are groups");
            //Assert.That(manageGroups.ThereAreGroups(), Is.False);
            var creategroup = manageGroups.ClickCreateGroup();

            creategroup = creategroup.FillCreateGroupForm(grpname, newUsers);

            var editGroup = creategroup.SaveNewGroup();

            // Edit Group With pre deifined groupname
            //Console.WriteLine("Press edit on " + grpname + " edit button");
            //var editGroup = manageGroups.EditGroup(grpname);
            //Console.WriteLine(PropertiesCollection.driver.Url);


            // Check if user is part of group. if so remove user.  
            Console.WriteLine("Check if user is part of group, if so remove from group");
            if (editGroup.IsgroupMember(_username))
                editGroup = editGroup.RemoveUser(_username);
            // Add users to group
            Console.WriteLine("Test to add two users " + newUsers);
            editGroup = editGroup.AddUsers(newUsers);

            // Assert change has happened
            Console.WriteLine("Test that Change has happened");
            Assert.That(editGroup.VerífyChage(), Is.True);

            // Test that Users is added.
            Console.WriteLine("Check that new users are added");
            Assert.That(editGroup.IsgroupMember(_username), Is.True);
            Assert.That(editGroup.IsgroupMember(_admin), Is.True);

            // remove user admin@admin.com
            Console.WriteLine("Remove " + _admin);
            editGroup = editGroup.RemoveUser(_admin);

            // Verify that that admin is removed.
            Console.WriteLine("Test That admin@admin is removed");
            Assert.That(editGroup.IsgroupMember(_admin), Is.False);

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

        [Test, Order(7)]
        public void MakeAQuizTest()
        {
            Console.WriteLine("Start Creating a Quiz");

            Console.WriteLine("Login");
            var dashboard = LogInPreTest(_username, _password);

            _UiTestQuizName = "UiTest_" + DateTime.UtcNow;

            Console.WriteLine("Get to create test by Dashboard page button.");

            var createTest = dashboard.CreateTest();

            Console.WriteLine("Start filling out form");
            createTest.CreateTestFillForm(_UiTestQuizName, "This is a UI Test Quiz", String.Empty, 1, 50);
            Console.WriteLine(_UiTestQuizName);
            Console.WriteLine("Fill in on Completion form");

            createTest.OnCompetionFillForm(true, true, "The test Quiz is run ");

            Console.WriteLine("Save Quiz");
            var setupQuestions = createTest.SaveChanges();

            Console.WriteLine("Add a Question");
            var addQuestion = setupQuestions.AddQuestion();

            Console.WriteLine("Set QuestionType and add question text");

            addQuestion.WriteQuestion(QuestionType.SingleChoice, "True or False?");

            addQuestion.SaveQuestion();
            Console.WriteLine("Add new answer(Correct)");
            addQuestion.OpenNewAnswer();
            addQuestion.AddAnswerTxtAndSave("True", true);

            Console.WriteLine("Adding non correctanswer");
            addQuestion.OpenNewAnswer();
            addQuestion.AddAnswerTxtAndSave("False", false);

            Console.WriteLine("Save Question and start a new question directly");
            var addaQuestion = addQuestion.NewQuestion();

            Console.WriteLine("Set QuestionType and add question text");

            addQuestion.WriteQuestion(QuestionType.MultipleChoice, "This,That and what?");

            addQuestion.SaveQuestion();
            Console.WriteLine("Add new answer(Correct)");
            addQuestion.OpenNewAnswer();
            addQuestion.AddAnswerTxtAndSave("Tis", true);

            Console.WriteLine("Adding non correctanswer");
            addQuestion.OpenNewAnswer(); Console.WriteLine("Opened new Question");
            addQuestion.AddAnswerTxtAndSave("Not", false);

            Console.WriteLine("Add new answer(Correct)");
            addQuestion.OpenNewAnswer();
            addQuestion.AddAnswerTxtAndSave("Whut", true);


            Console.WriteLine("Save and return to manage question site");
            var managequestions = addQuestion.SaveAndReturn();

            Console.WriteLine("Return to home");
            dashboard = managequestions.ReturnToDashboard();


            Console.WriteLine("Verify that test is made and visible");
            Assert.That(dashboard.FindQuiz(_UiTestQuizName), Is.True);


        }

        [Test, Order(8)]
        public void TakeAQuizTest()
        {
            Console.WriteLine("Start TakeAQuizTest");
            string[] _correctAnswers = new string[] { "True", "Tis", "Whut" };
            Console.WriteLine("Login");
            var dashboard = LogInPreTest(_username, _password);

            Console.WriteLine("Assert that test exist.");
            Assert.That(dashboard.FindQuiz("UiTest_"), Is.True);

            Console.WriteLine("Take Test as admin");
            var session = dashboard.TakeTestAsAdmin("UiTest_");

            Console.WriteLine("Start Quiz!");
            var test = session.StartTest();

            Console.WriteLine("First Question expect answer True");

            test = test.AnsweQuizQuestion(_correctAnswers[0]);
            Console.WriteLine("Click Next");
            test = test.ClickNext();

            Console.WriteLine("Next Question");
            Console.WriteLine("First answer second question");
            test = test.AnsweQuizQuestion(_correctAnswers[1]);
            Console.WriteLine("Second answer second question");
            test = test.AnsweQuizQuestion(_correctAnswers[2]);

            Console.WriteLine("Click Submit");
            var completed = test.ClickSubmit();

            Console.WriteLine("Asserting success");
            Assert.That(completed.TestSuccsess, Is.True);
            Console.WriteLine("Return to Dashboard");
            dashboard = completed.ClickHomeBtn();

            Console.WriteLine("TakeAQuizTest Completed");
        }


        private DashboardPageObject LogInPreTest(string usr, string pswd)
        {
            Console.WriteLine("Running Login Sequence");

            string LoginUrl = "http://localhost:27015/Account/Login";
            PropertiesCollection.driver.Manage().Window.Maximize();
            PropertiesCollection.driver.Navigate().GoToUrl(LoginUrl);
            Console.WriteLine(PropertiesCollection.driver.Url);

            SignInPageObject pageLogin = new SignInPageObject();
            var dashboard = pageLogin.Signin(usr, pswd);
            Assert.That(dashboard.FindIsHome);
            Console.WriteLine(PropertiesCollection.driver.Url);
            Console.WriteLine("Login Sequence finished");

            return dashboard;

        }



        private string AccessTest(string testUrl)
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
