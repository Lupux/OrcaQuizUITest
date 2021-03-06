﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace OrcaQuizUITest.Pages
{
    internal class EditGroupPageObject : PageObject
    {
        public EditGroupPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
        
        [FindsBy(How = How.CssSelector, Using = "[uitest='txtViewBag']")]
        public IWebElement TxtViewBag { get; set; }


        //[FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_btn_back_top']")]
        //public IWebElement BtnBackTop { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='txtEditGroupName']")]
        public IWebElement TxtEditGroupName { get; set; }

        [FindsBy(How = How.Id, Using = "NewUserEmails")]
        public IWebElement TxtNewUsers { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='btnSaveEdit']")]
        public IWebElement BtnSaveEdit { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "[uitest='txtGrpIsEmpty']")]
        public IWebElement TxtGrpIsEmpty { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='btnBack']")]
        public IWebElement BtnBackBottom { get; set; }


        internal bool GroupIsEmpty()
        {
            try
            {
                return TxtGrpIsEmpty.Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

        internal EditGroupPageObject AddUsers(string users)
        {
            TxtNewUsers.EnterText(users);

            BtnSaveEdit.Clicks();

            return this;
        }

        internal EditGroupPageObject RemoveUser(string user)
        {
            PropertiesCollection.driver.FindElement(By.CssSelector("[uitest*='btnRemove_" + user+"']")).Click();
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.StalenessOf(PropertiesCollection.driver.FindElement(By.Id(user))) );
            return this;
        }
               
        internal EditGroupPageObject EditGroupName(string grpName)
        {
            TxtEditGroupName.EnterText(grpName);
            BtnSaveEdit.Clicks();
            return this;
        }

        //internal ManageGroupsPageObject TopGoBack()
        //{
        //    BtnBackTop.Clicks();
        //    return new ManageGroupsPageObject();
        //}
        internal ManageGroupsPageObject BottomGoBack()
        {
            BtnBackBottom.Clicks();
            return new ManageGroupsPageObject();
        }

        internal bool IsgroupMember(string user)
        {
            try
            {
                return PropertiesCollection.driver.FindElement(By.Id(user)).Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

        internal bool VerífyChage()
        {
            try
            {
                return TxtViewBag.Displayed;
            }
            catch (NoSuchElementException)
            {

                return false; 
            }
        }

    }
}