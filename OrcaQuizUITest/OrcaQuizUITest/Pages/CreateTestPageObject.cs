using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OrcaQuizUITest.Pages
{
    internal class CreateTestPageObject : PageObject
    {
        public CreateTestPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);

        }
        [FindsBy(How = How.CssSelector, Using = "buttn[class*= 'UI_test_Btn_Back_top']")]
        public IWebElement BtnBack { get; set; }

        [FindsBy(How = How.CssSelector, Using = "buttn[class*= 'UI_test_Btn_Save_top']")]
        public IWebElement BtnSaveTop { get; set; }

        [FindsBy(How = How.Id, Using = "TestName")]
        public IWebElement TxtTestName { get; set; }


        [FindsBy(How = How.Id, Using = "Description")]
        public IWebElement TxtTestDescription{ get; set; }

        [FindsBy(How = How.Id, Using = "Tags")]
        public IWebElement TxtTestTags { get; set; }

        [FindsBy(How = How.Id, Using = "TimeLimitInMinutes")]
        public IWebElement TxtTestTimeInMinutes{ get; set; }

        [FindsBy(How = How.Id, Using = "PassPercentage")]
        public IWebElement TxtTestPassPercentage { get; set; }

        [FindsBy(How = How.Id, Using = "ShowPassOrFailCheckboxID")]
        public IWebElement CheckBoxShowPassOrFail{ get; set; }

        [FindsBy(How = How.Id, Using = "ShowTestScore")]
        public IWebElement CheckBoxShowTestScore { get; set; }

        [FindsBy(How = How.Id, Using = "CustomCompletionMessage")]
        public IWebElement TxtCustomCompletionMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "buttn[class*= 'UI_test_Btn_Back']")]
        public IWebElement BtnBackBottom { get; set; }

        [FindsBy(How = How.Id, Using = "saveButton")]
        public IWebElement BtnSave { get; set; }



    }
}