using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace OrcaQuizUITest.Pages
{
    internal class TestSessionPageObject : PageObject
    {
        public TestSessionPageObject() 
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);

        }

        
         [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_btn_backToHome']")]
        private IWebElement BtnBack { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_StartTestBtn']")]
        private IWebElement BtnStartTest { get; set; }

       

        internal QuizQuestionPageObject StartTest()
        {
          
            BtnStartTest.Clicks();
            return new QuizQuestionPageObject();
        }




    }
}