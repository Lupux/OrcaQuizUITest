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
        private IWebElement TxtFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement TxtLastName { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement TxtEmail { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "PasswordCheck")]
        private IWebElement TxtPasswordCheck { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='btnRegister']")]
        private IWebElement RegisterBtn { get; set; }
        #endregion

        [FindsBy(How = How.CssSelector, Using = "[uitest='linkLogin']")]
        private IWebElement LoginLink { get; set; }

      
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
        #endregion

        internal StartPageObject TestHomeButton()
        {
            TL_HomeBtn.Clicks();

            return new StartPageObject();
        }

        internal SignInPageObject LinkToSignin()
        {
            LoginLink.Clicks();

            return new SignInPageObject();
        }

        internal RegisterPageObject TestRegisterNavBarLink()
        {
            TR_RegisterBtn.Clicks();
            return new RegisterPageObject();
        }

        internal SignInPageObject TestSignInNavBarLink()
        {
            TR_SignInBtn.Clicks();
            return new SignInPageObject();
        }

        internal RegisterPageObject FillRegisterForm(string firstname, string lastname, string email, string password, string repeatpassword)
        {
            TxtFirstName.EnterText(firstname);
            TxtLastName.EnterText(lastname);
            TxtEmail.EnterText(email);
            TxtPassword.EnterText(password);
            TxtPasswordCheck.EnterText(repeatpassword);

            return this;
        }

        internal DashboardPageObject ClickRegisterButton()
        {
            RegisterBtn.Clicks();
            return new DashboardPageObject();
        }

    }
}