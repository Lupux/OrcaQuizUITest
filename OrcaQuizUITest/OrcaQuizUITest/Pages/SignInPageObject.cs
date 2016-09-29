using System;
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
        [FindsBy(How = How.CssSelector, Using = "[uitest='txtUserName']")]
        public IWebElement TxtUsername { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='txtPassword']")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='btnSignIn']")]
        public IWebElement SignInBtn { get; set; }
        #endregion

        [FindsBy(How = How.CssSelector, Using = "[uitest='linkRegister']")]
        public IWebElement RegisterLink { get; set; }

        #region Generic Signin/register buttons
        //Generic Many pages buttons
        // Top Right corner buttons/links
        [FindsBy(How = How.CssSelector, Using = "[uitest='linkNavBarRegister']")]
        public IWebElement TR_RegisterBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='linkNavBarSignin']")]
        public IWebElement TR_SignInBtn { get; set; }
        #endregion

        #region Generic all Pages Buttons
        // Generic All pages Button
        // Top Left corner Button
        [FindsBy(How = How.CssSelector, Using = "[uitest='navBrand']")]
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

        public RegisterPageObject LinkToRegister()
        {
            RegisterLink.Clicks();

            return new RegisterPageObject();
        }

        public RegisterPageObject TestRegisterNavBarLink()
        {
            TR_RegisterBtn.Clicks();
            return new RegisterPageObject();
        }

        public SignInPageObject TestSignInNavBarLink()
        {
            TR_SignInBtn.Clicks();
            return new SignInPageObject();
        }

        internal void ClearTextBoxes()
        {
            TxtUsername.Clear();
            TxtPassword.Clear();
        }
    }
}