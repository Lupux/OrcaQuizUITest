using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;
using System;

namespace OrcaQuizUITest.Pages
{
    internal class EditQuestionsPageObject : PageObject
    {
        public EditQuestionsPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        #region EditQuestion
        [FindsBy(How = How.Id, Using = "dropQuestionType")]
        private IWebElement DDLQuestionType { get; set; }

        [FindsBy(How = How.Id, Using = "SortOrder")]
        private IWebElement TxtSortOrder { get; set; }

        [FindsBy(How = How.Id, Using = "mceQuestionBox")]
        private IWebElement TxtQuestionText{ get; set; }

        [FindsBy(How = How.Id, Using = "HasComment")]
        private IWebElement CheckBoxHasComment { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_btn_saveQ']")]
        private IWebElement BtnSaveQuestion { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_btn_backToHome']")]
        private IWebElement BtnBackHome { get; set; }
        #endregion
        #region Modal
        [FindsBy(How = How.CssSelector, Using = "button[class*= 'close']")]
        private IWebElement BtnModalX { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_Modal_btn_Cancel']")]
        private IWebElement BtnModalCancel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_Modal_btn_RemoveQ']")]
        private IWebElement BtnModalRemoveQuestion { get; set; }
        #endregion

        #region Answers

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_btn_AddAnswer']")]
        private IWebElement BtnAddAnswer{ get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_btn_SaveAndExit']")]
        private IWebElement BtnSaveAndExit { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_NewQuestion']")]
        private IWebElement BtnNewQuestiont { get; set; }

        #endregion




        internal EditQuestionsPageObject WriteQuestion(QuestionType type, string questionText)
        {
            if (type == QuestionType.SingleChoice)
                DDLQuestionType.SelectDropDown("Singel Choice");
            if (type == QuestionType.MultipleChoice)
                DDLQuestionType.SelectDropDown("Multiple Choice");

            TxtQuestionText.EnterText(questionText);

            return this;
        }

        internal EditQuestionsPageObject ClickHasComment()
        {
            CheckBoxHasComment.Clicks();
            return this;
        }

        internal EditQuestionsPageObject SaveQuestion()
        {
            BtnSaveQuestion.Clicks();
            return new EditQuestionsPageObject();
        }

        internal EditQuestionsPageObject AddAnswer(string answerTxt, bool isCorrect)
        {


            // Get answerId from URL
            string url = PropertiesCollection.driver.Url;
            var urlList = url.Split('/');
            string answerId = urlList[urlList.Length -1];

            // Enter Answer
            PropertiesCollection.driver.FindElement(By.Id("mceAnswerBox"+ answerId)).EnterText(answerTxt);

            if (isCorrect)
                PropertiesCollection.driver.FindElement(By.Id("answerIsCorrect" + answerId)).Clicks();

            // Save Answer
            PropertiesCollection.driver.FindElement(By.Id("btnEditAnswer" + answerId)).Clicks();

            return this;
        }

    }
}