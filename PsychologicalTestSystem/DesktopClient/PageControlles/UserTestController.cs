using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DesktopClient.Pages;
using TestLogic.TestEntityes;

namespace DesktopClient.PageControlles
{
    class UserTestController : IPageController
    {
        private UserTest _controllerPage;
        private Window _controllerWindow;
        private MainPageController _controller;

        private int CurrentQuestion;

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
        }

        void Button_Yes_Click(object sender, RoutedEventArgs e)
        {
            if (IsLast())
            {
                var currentQuestion = GetCurrentQuestion();

                currentQuestion.FirstAnswer.IsCheked = true;

                _controller.GoToTestResultPage();
            }
            else
            {
                var currentQuestion = GetCurrentQuestion();

                currentQuestion.FirstAnswer.IsCheked = true;

                CurrentQuestion++;

                Init();
            }  
        }

        void Button_Sometimes_Click(object sender, RoutedEventArgs e)
        {
            if (IsLast())
            {
                var currentQuestion = GetCurrentQuestion();

                currentQuestion.SecondAnswer.IsCheked = true;

                _controller.GoToTestResultPage();
            }
            else
            {
                var currentQuestion = GetCurrentQuestion();

                currentQuestion.SecondAnswer.IsCheked = true;

                CurrentQuestion++;

                Init();
            } 
        }

        void Button_No_Click(object sender, RoutedEventArgs e)
        {
            if (IsLast())
            {
                var currentQuestion = GetCurrentQuestion();

                currentQuestion.ThirdAnswer.IsCheked = true;

                _controller.GoToTestResultPage();
            }
            else
            {
                var currentQuestion = GetCurrentQuestion();

                currentQuestion.ThirdAnswer.IsCheked = true;

                CurrentQuestion++;

                Init();
            }           
        }

        public void SetupToWindow()
        {
            _controllerWindow.Content = _controllerPage;

            Init();
        }

        private void Init()
        {
            var currentQuestion = GetCurrentQuestion();

            _controllerPage.Label_Question.Content = currentQuestion.QuestionMessage;

            _controllerPage.Button_Yes.Content = currentQuestion.FirstAnswer.Text;
            _controllerPage.Button_Sometimes.Content = currentQuestion.SecondAnswer.Text;
            _controllerPage.Button_No.Content = currentQuestion.ThirdAnswer.Text;
        }

        private Question GetCurrentQuestion()
        {
            return _controller.Test.Questions[CurrentQuestion];
        }

        private bool IsLast()
        {
            return _controller.Test.Questions.Count - 1 == CurrentQuestion;
        }
    }
}
