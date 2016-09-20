using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;

namespace OrcaQuizUITest.Pages
{
    public class SignInPageObject
    {
        public SignInPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        #region Sign in form
        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement TxtUsername { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "SignInBtn")]
        public IWebElement SignInBtn { get; set; }
        #endregion

        // Place for a href link to RegisterPage

        #region Generic Signin/register buttons
        //Generic Many pages buttons
        // Top Right corner buttons/links
        [FindsBy(How = How.Id, Using = "Register")]
        public IWebElement TR_RegisterBtn { get; set; }

        [FindsBy(How = How.Id, Using = "SignIn")]
        public IWebElement TR_SignInBtn { get; set; }
        #endregion

        #region Generic all Pages Buttons
        // Generic All pages Button
        // Top Left corner Button
        [FindsBy(How = How.ClassName, Using = "navbar-brand")]
        public IWebElement TL_HomeBtn { get; set; }
       
        public StartPageObject TestHomeButton()
        {
            TL_HomeBtn.Clicks();

            return new StartPageObject();
        }
        #endregion
        // Test Cases
        public DashboardPageObject Signin(string username, string password)
        {
            TxtUsername.SendKeys(username);

            TxtPassword.SendKeys(password);

            SignInBtn.Click();

            // Return the page object
            return new DashboardPageObject();
        }
    }
}