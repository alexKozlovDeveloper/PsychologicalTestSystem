using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DesktopClient.Pages;

namespace DesktopClient.PageControlles
{
    class UserIntroductionController : IPageController
    {
        private UserIntroduction _controllerPage;
        private Window _controllerWindow;
        private MainPageController _controller;

        public UserIntroduction ControllerPage
        {
            get { return _controllerPage; }
        }

        public Window ControllerWindow
        {
            get { return _controllerWindow; }
        }

        public UserIntroductionController(Window window, MainPageController controller)
        {
            _controllerWindow = window;
            _controller = controller;

            _controllerPage = new UserIntroduction();

            _controllerPage.Button_Back.Click += Button_Back_Click;
            _controllerPage.Button_StartTest.Click += Button_StartTest_Click;
        }

        void Button_StartTest_Click(object sender, RoutedEventArgs e)
        {
            _controller.GoToUserTestPage();
            //throw new NotImplementedException();
        }

        void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            _controller.GoToUserRegistrationPage();
            //throw new NotImplementedException();
        }

        public void SetupToWindow()
        {
            _controllerWindow.Content = _controllerPage;
        }
    }
}
