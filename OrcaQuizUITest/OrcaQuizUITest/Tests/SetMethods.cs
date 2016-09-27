using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcaQuizUITest.Tests
{
    public static class SetMethods
    {
        /// <summary>
        /// Extended method for entering text in the contrl
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        /// <summary>
        ///  Click function button, checkbox, option etc
        /// </summary>
        /// <param name="element"></param>
        public static void Clicks(this IWebElement element) { element.Click(); }


        /// <summary>
        /// Selecting DropDown
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SelectDropDown(this IWebElement element, string value) { new SelectElement(element).SelectByText(value); }



    }
}
