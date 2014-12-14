using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DesktopClient.Helpers;
using TestLogic.TestEntityes;

namespace DesktopClient.PageControlles
{
    class MainPageController
    {
        private Window _mainWindow;

        private UserIntroductionController _userIntroductionController;
        private UserRegistrationController _userRegistrationController;
        private UserTestResultController _userTestResultController;
        private UserTestController _userTestController;

        private Test _test;

        public Test Test
        {
            get
            {
                return _test;
            }
        }

        public MainPageController(Window mainWindow)
        {
            _mainWindow = mainWindow;

            _userIntroductionController = new UserIntroductionController(mainWindow, this);
            _userRegistrationController = new UserRegistrationController(mainWindow, this);
            _userTestResultController = new UserTestResultController(mainWindow, this);
            _userTestController = new UserTestController(mainWindow, this);

            _userRegistrationController.SetupToWindow();


            _test = new Test();

            _test.Introduction = @"Для прохождения теста нажмите на кнопку <Начать тест>.
Для внимательно читайте вопросы и отвечайте на них нажимаю на кнопку с наиболее подходяшим ответом.
";
            _test.Questions = new List<Question> 
            {
                new Question
                {
                    QuestionMessage = @"Иногда испытывается психологический дискомфорт ввиду отсутствия 
возможности поделиться своими проблемами с родителями",
                    FirstAnswer = new Answer
                    {
                        Text = "Да",
                        ReportMessage = ""
                    },
                    SecondAnswer = new Answer
                    {
                        Text = "Иногда",
                        ReportMessage = ""
                    },
                    ThirdAnswer = new Answer
                    {
                        Text = "Нет",
                        ReportMessage = "составить распорядок дня"
                    }
                },
                new Question
                {
                    QuestionMessage = @"Question 2 ololo",
                    FirstAnswer = new Answer
                    {
                        Text = "da",
                        ReportMessage = ""
                    },
                    SecondAnswer = new Answer
                    {
                        Text = "net",
                        ReportMessage = ""
                    },
                    ThirdAnswer = new Answer
                    {
                        Text = "oy vse",
                        ReportMessage = "участвовать в мероприятиях вне вуза"
                    }
                },
                new Question
                {
                    QuestionMessage = @"Question 3 ololo",
                    FirstAnswer = new Answer
                    {
                        Text = "da",
                        ReportMessage = "lal7"
                    },
                    SecondAnswer = new Answer
                    {
                        Text = "net",
                        ReportMessage = "lal8"
                    },
                    ThirdAnswer = new Answer
                    {
                        Text = "oy vse",
                        ReportMessage = ""
                    }
                },
                new Question
                {
                    QuestionMessage = @"Question 4 ololo",
                    FirstAnswer = new Answer
                    {
                        Text = "da",
                        ReportMessage = "lal10"
                    },
                    SecondAnswer = new Answer
                    {
                        Text = "net",
                        ReportMessage = ""
                    },
                    ThirdAnswer = new Answer
                    {
                        Text = "oy vse",
                        ReportMessage = ""
                    }
                }
            };


            //var ms = XmlSerializerHelper.Serialize<Test>(test);

            //FileReaderHelper.WriteStreamInFile(ms, @"D:\test1.xml");

        }

        public void GoToUserIntroductionPage()
        {
            _userIntroductionController.SetupToWindow();
        }

        public void GoToUserRegistrationPage()
        {
            _userRegistrationController.SetupToWindow();
        }

        public void GoToTestResultPage()
        {
            _userTestResultController.SetupToWindow();
        }

        public void GoToUserTestPage()
        {
            _userTestController.SetupToWindow();
        }

    }
}
