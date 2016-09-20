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
        [FindsBy(How = How.Id, Using = "UI_test_Btn_Register_BigScreen")]
        public IWebElement C_B_RegisterBtn { get; set; }

        [FindsBy(How = How.Id, Using = "UI_test_Btn_Login_BigScreen")]
        public IWebElement C_B_SignInBtn { get; set; }
        
        // Small Screen Center Buttons
        [FindsBy(How = How.Id, Using = "UI_test_Btn_Register_SmalScreen")]
        public IWebElement C_S_RegisterBtn { get; set; }

        [FindsBy(How = How.Id, Using = "UI_test_Btn_Login_SmallScreen")]
        public IWebElement C_S_SignInBtn { get; set; }

        #region Generic Signin/register buttons
        //Generic Many pages buttons
        // Top Right corner buttons/links
        [FindsBy(How = How.Id, Using = "UI_test_Link_Register")]
        public IWebElement TR_RegisterBtn { get; set; }

        [FindsBy(How = How.Id, Using = "UI_test_Link_Signin")]
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
            C_B_RegisterBtn.Clicks();

            return new RegisterPageObject();
        }

        public SignInPageObject TestSignInCenterBtn()
        {
            C_B_SignInBtn.Clicks();

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
