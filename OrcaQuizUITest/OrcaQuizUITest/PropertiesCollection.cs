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

    enum AdminChoiseType
    {
        ManageGroup,
        CreateGroup,
        ManageUsers,
        CreateTest,
        ManageTest,
        UserStatistics,
        GroupStatistics
    }

    enum QuestionType
    {
        SingleChoice,
        MultipleChoice,
        TextSingleLine,
        TextMultiLine
    }


    class PropertiesCollection
    {

        // Auto-Implemented Property
        public static IWebDriver driver { get; set; }

    }
}
