using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;

namespace OrcaQuizUITest.Pages
{
    public class RegisterPageObject 
    {
        public RegisterPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        #region Register form
        [FindsBy(How = How.Id, Using = "FirstName")]
        public IWebElement TxtFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        public IWebElement TxtLastName { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement TxtEmail { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "PasswordCheck")]
        public IWebElement TxtPasswordCheck { get; set; }

        [FindsBy(How = How.CssSelector, Using = "buttn[class*= 'UI_test_Btn_Register']")]
        public IWebElement RegisterBtn { get; set; }
        #endregion

        [FindsBy(How = How.ClassName, Using = "UI_test_Link_Login")]
        public IWebElement LoginLink { get; set; }

        #region Generic Signin/register buttons
        //Generic Many pages buttons
        // Top Right corner buttons/links
        [FindsBy(How = How.ClassName, Using = "UI_test_Link_Register")]
        public IWebElement TR_RegisterBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "UI_test_Link_Signin")]
        public IWebElement TR_SignInBtn { get; set; }
        #endregion

        #region Generic all Pages Buttons
        // Generic All pages Button
        // Top Left corner Button
        [FindsBy(How = How.ClassName, Using = "navbar-brand")]
        public IWebElement TL_HomeBtn { get; set; }
        #endregion
        public StartPageObject TestHomeButton()
        {
            TL_HomeBtn.Clicks();

            return new StartPageObject();
        }

        public SignInPageObject LinkToSignin()
        {
            LoginLink.Clicks();

            return new SignInPageObject();
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


    }
}