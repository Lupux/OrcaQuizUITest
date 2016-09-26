using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
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

        [FindsBy(How = How.Id, Using = "editQuestionTextDiv")]
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
        private IWebElement BtnNewQuestion { get; set; }

        #endregion




        internal EditQuestionsPageObject WriteQuestion(QuestionType type, string questionText)
        {
            if (type == QuestionType.SingleChoice)
                DDLQuestionType.SelectDropDown("Single Choice");
            if (type == QuestionType.MultipleChoice)
                DDLQuestionType.SelectDropDown("Multiple Choice");
            // put text in iframeobject
            PropertiesCollection.driver.SwitchTo().Frame("mceQuestionBox_ifr").FindElement(By.Id("tinymce")).EnterText(questionText);
            // Return to Current default usage
            PropertiesCollection.driver.SwitchTo().DefaultContent();


            //TxtQuestionText.EnterText(questionText);

            return this;
        }

        internal EditQuestionsPageObject ClickHasComment()
        {
            //CheckBoxHasComment.Clicks();
            new Actions(PropertiesCollection.driver).MoveToElement(CheckBoxHasComment).Release(CheckBoxHasComment).Build().Perform();
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(20));
            wait.Until<IWebElement>(ExpectedConditions.ElementToBeClickable(CheckBoxHasComment)).Clicks();
            return this;
        }

        internal EditQuestionsPageObject SaveQuestion()
        {
            //BtnSaveQuestion.Clicks();
            new Actions(PropertiesCollection.driver).MoveToElement(BtnSaveQuestion).Release(BtnSaveQuestion).Build().Perform();
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(20));
            wait.Until<IWebElement>(ExpectedConditions.ElementToBeClickable(BtnSaveQuestion)).Clicks();
            return new EditQuestionsPageObject();
        }

        internal EditQuestionsPageObject OpenNewAnswer()
        {
            //BtnAddAnswer.Clicks();
            //var element = PropertiesCollection.driver.FindElement(By.Id("btnEditAnswer" + answerId));
            new Actions(PropertiesCollection.driver).MoveToElement(BtnAddAnswer).Release(BtnAddAnswer).Build().Perform();
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(20));
            wait.Until<IWebElement>(ExpectedConditions.ElementToBeClickable(BtnAddAnswer)).Clicks();

            return new EditQuestionsPageObject();
        }


        internal EditQuestionsPageObject AddAnswerTxtAndSave(string answerTxt, bool isCorrect)
        {
            

            // Get answerId from URL
            string url = PropertiesCollection.driver.Url;
            var urlList = url.Split('/');
            string answerId = urlList[urlList.Length -1];

            // Enter Answer
            // put text in iframeobject
            PropertiesCollection.driver.SwitchTo().Frame("mceAnswerBox"+ answerId+ "_ifr").FindElement(By.Id("tinymce")).EnterText(answerTxt);
            // Return to Current default usage
            PropertiesCollection.driver.SwitchTo().DefaultContent();
            
            if (isCorrect)
                PropertiesCollection.driver.FindElement(By.Id("answerIsCorrect" + answerId)).Clicks();

            // Save Answer
            var element = PropertiesCollection.driver.FindElement(By.Id("btnEditAnswer" + answerId));
            new Actions(PropertiesCollection.driver).MoveToElement(element).Release(element).Build().Perform();
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(20));
            wait.Until<IWebElement>(ExpectedConditions.ElementToBeClickable(element)).Clicks();

            //PropertiesCollection.driver.FindElement(By.Id("btnEditAnswer" + answerId)).Clicks();

            return this;
        }

        internal EditQuestionsPageObject NewQuestion()
        {
            BtnNewQuestion.Clicks();

            return new EditQuestionsPageObject();
        }

        internal ManageQuestionsPageObject SaveAndReturn()
        {
            BtnSaveAndExit.Clicks();
            return new ManageQuestionsPageObject();
        }


    }
}