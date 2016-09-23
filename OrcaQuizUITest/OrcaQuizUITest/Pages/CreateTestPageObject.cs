using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;


namespace OrcaQuizUITest.Pages
{
    internal class CreateTestPageObject : PageObject
    {
        public CreateTestPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);

        }

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_Btn_Back_top']")]
        private IWebElement BtnBack { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_Btn_Save_top']")]
        private IWebElement BtnSaveTop { get; set; }

        [FindsBy(How = How.Id, Using = "TestName")]
        private IWebElement TxtTestName { get; set; }


        [FindsBy(How = How.Id, Using = "Description")]
        private IWebElement TxtTestDescription{ get; set; }

        [FindsBy(How = How.Id, Using = "Tags")]
        private IWebElement TxtTestTags { get; set; }

        [FindsBy(How = How.Id, Using = "TimeLimitInMinutes")]
        private IWebElement TxtTestTimeInMinutes{ get; set; }

        [FindsBy(How = How.Id, Using = "PassPercentage")]
        private IWebElement TxtTestPassPercentage { get; set; }

        [FindsBy(How = How.Id, Using = "ShowPassOrFailCheckboxID")]
        private IWebElement CheckBoxShowPassOrFail{ get; set; }

        [FindsBy(How = How.Id, Using = "ShowTestScore")]
        private IWebElement CheckBoxShowTestScore { get; set; }

        [FindsBy(How = How.Id, Using = "CustomCompletionMessage")]
        private IWebElement TxtCustomCompletionMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_Btn_Back']")]
        private IWebElement BtnBackBottom { get; set; }

        [FindsBy(How = How.Id, Using = "saveButton")]
        private IWebElement BtnSave { get; set; }

        internal CreateTestPageObject CreateTestFillForm(string name, string description, string tags, int timeInMinutes, int passProcent)
        {
            TxtTestName.EnterText(name);
            TxtTestDescription.EnterText(description);
            TxtTestTags.EnterText(tags);
            TxtTestTimeInMinutes.EnterText(timeInMinutes.ToString());
            TxtTestPassPercentage.EnterText(passProcent.ToString());
            return this;
        }


        internal CreateTestPageObject OnCompetionFillForm(bool showPassorFail, bool showTestScore, string customCompleteMessage)
        {
            if (showPassorFail)
                CheckBoxShowPassOrFail.Clicks();
            if (showTestScore)
                CheckBoxShowTestScore.Clicks();

            TxtCustomCompletionMessage.EnterText(customCompleteMessage);

            return this;
        }

        internal PageObject SaveChanges()
        {
            BtnSave.Clicks();
            return new ManageQuestionsPageObject();
        }
    }
}