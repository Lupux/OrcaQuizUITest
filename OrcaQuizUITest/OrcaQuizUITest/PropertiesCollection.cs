using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcaQuizUITest
{
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName

    }
    class PropertiesCollection
    {

        // Auto-Implemented Property
        public static IWebDriver driver { get; set; }

    }
}
