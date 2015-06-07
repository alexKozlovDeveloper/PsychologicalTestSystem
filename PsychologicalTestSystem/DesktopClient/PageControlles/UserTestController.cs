using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DesktopClient.Conf;
using DesktopClient.Pages;
using Db.Core.TableEntityes;

namespace DesktopClient.PageControlles
{
    class UserTestController : IPageController
    {
        private UserTest _controllerPage;
        private Window _controllerWindow;
        private MainPageController _controller;

        private int CurrentQuestion;

        private List<string> report;

        public UserTest ControllerPage
        {
            get { return _controllerPage; }
        }

        public Window ControllerWindow
        {
            get { return _controllerWindow; }
        }

        public UserTestController(Window window, MainPageController controller)
        {
            _controllerWindow = window;
            _controller = controller;

            _controllerPage = new UserTest();

            _controllerPage.Button_No.Click += Button_No_Click;
            _controllerPage.Button_Sometimes.Click += Button_Sometimes_Click;
            _controllerPage.Button_Yes.Click += Button_Yes_Click;

            CurrentQuestion = 0;

            report = new List<string>();
        }

        void Button_Yes_Click(object sender, RoutedEventArgs e)
        {
            AddQuestionResult(1);

            if (IsLast())
            {
                _controller.GoToTestResultPage(report);
            }
            else
            {
                CurrentQuestion++;

                Init();
            }  
        }

        void Button_Sometimes_Click(object sender, RoutedEventArgs e)
        {
            AddQuestionResult(2);

            if (IsLast())
            {
                _controller.GoToTestResultPage(report);
            }
            else
            {
                CurrentQuestion++;

                Init();
            } 
        }

        void Button_No_Click(object sender, RoutedEventArgs e)
        {
            AddQuestionResult(3);

            if (IsLast())
            {
                _controller.GoToTestResultPage(report);
            }
            else
            {
                CurrentQuestion++;

                Init();
            }           
        }

        private void AddQuestionResult(int answerNumber)
        {
            var ques = GetCurrentQuestion();

            //var reportMes = answerNumber == 1 ? ques.FirstReportMessage : answerNumber == 2 ? ques.SecondReportMessage : ques.ThirdReportMessage;

            //report.Add(reportMes);

            _controller.Repository.AddTestingResult(ques.Id, answerNumber, AppConfig.CurrentPassingTest.Id);
        }

        public void SetupToWindow()
        {
            _controllerWindow.Content = _controllerPage;

            CurrentQuestion = 0;

            Init();
        }

        private void Init()
        {
            var currentQuestion = GetCurrentQuestion();

            _controllerPage.Label_Question.Content = currentQuestion.Message;

            _controllerPage.Button_Yes.Content = currentQuestion.FirstAnswer;
            _controllerPage.Button_Sometimes.Content = currentQuestion.SecondAnswer;
            _controllerPage.Button_No.Content = currentQuestion.ThirdAnswer;
        }

        private Question GetCurrentQuestion()
        {
            var questions = _controller.Repository.GetQuestions(AppConfig.SelectedTest.Id).ToList();
            return questions[CurrentQuestion];
        }

        private bool IsLast()
        {
            var questions = _controller.Repository.GetQuestions(AppConfig.SelectedTest.Id).ToList();
            return questions.Count - 1 == CurrentQuestion;
        }
    }
}
