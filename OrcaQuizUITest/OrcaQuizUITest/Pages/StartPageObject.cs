﻿using OpenQA.Selenium;
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

        // Big Center Buttons
        [FindsBy(How = How.Id, Using = "Register")]
        public IWebElement C_RegisterBtn { get; set; }

        [FindsBy(How = How.Id, Using = "SignIn")]
        public IWebElement C_SignInBtn { get; set; }

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
        #endregion

        // TestCases:
        public RegisterPageObject TestRegisterCenterBtn()
        {
            C_RegisterBtn.Clicks();

            return new RegisterPageObject();
        }

        public SignInPageObject TestSignInrCenterBtn()
        {
            C_SignInBtn.Clicks();

            return new SignInPageObject();
        }

        public StartPageObject TestHomeButton()
        {
            TL_HomeBtn.Clicks();

                return this;
        }


    }
}
