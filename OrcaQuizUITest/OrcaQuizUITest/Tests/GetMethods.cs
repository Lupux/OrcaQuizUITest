using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcaQuizUITest.Tests
{
    public static class GetMethods
    {


        /// <summary>
        /// Get Value from a textbox.
        /// </summary>
        public static string GetText(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        /// <summary>
        /// Get Text from DropDown List
        /// </summary>
        public static string GetTextDDL(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }
    }
}
