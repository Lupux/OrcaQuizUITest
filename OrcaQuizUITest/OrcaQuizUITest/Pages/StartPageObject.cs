using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcaQuizUITest.Pages
{
    public class StartPageObject
    {
        public StartPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        // Big Screen Center Buttons
        [FindsBy(How = How.CssSelector, Using = "[ uitest='btnRegister']")]
        public IWebElement C_RegisterBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='btnLogin']")]
        public IWebElement C_SignInBtn { get; set; }
        
        

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

        // TestCases:
        public RegisterPageObject TestRegisterCenterBtn()
        {
            C_RegisterBtn.Clicks();

            return new RegisterPageObject();
        }

        public SignInPageObject TestSignInCenterBtn()
        {
            C_SignInBtn.Clicks();

            return new SignInPageObject();
        }

        public StartPageObject TestHomeButton()
        {
            TL_HomeBtn.Clicks();

                return this;
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
