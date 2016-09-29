using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace OrcaQuizUITest.Pages
{
    internal class QuizQuestionPageObject : PageObject
    {
        public QuizQuestionPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        

        [FindsBy(How = How.CssSelector, Using = "[uitest='btnPreviusQuestion']")]
        private IWebElement BtnPrevius { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='btnNextQuestion']")]
        private IWebElement BtnNext { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='btnSubmitQuiz']")]
        private IWebElement BtnSubmit { get; set; }



        internal QuizQuestionPageObject AnsweQuizQuestion(string answer)
        {
           
                var element = PropertiesCollection.driver.FindElement(By.XPath("//span[contains(text(), '" + answer + "')]"));

                if (element.Displayed)
                {
                    Console.WriteLine("Answer to click: "+ element.Text);
                    element.Clicks();
                }
          
           
            return this;
        }

        internal QuizQuestionPageObject ClickNext()
        {
            BtnNext.Clicks();

            return new QuizQuestionPageObject();
        }

        internal TestSessionFinishedPageObject ClickSubmit()
        {
            BtnSubmit.Clicks();

            return new TestSessionFinishedPageObject();
        }

    }
}