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
    class UserTestResultController : IPageController
    {
        private UserTestResult _controllerPage;
        private Window _controllerWindow;
        private MainPageController _controller;

        public UserTestResult ControllerPage
        {
            get { return _controllerPage; }
        }

        public Window ControllerWindow
        {
            get { return _controllerWindow; }
        }

        public UserTestResultController(Window window, MainPageController controller)
        {
            _controllerWindow = window;
            _controller = controller;

            _controllerPage = new UserTestResult();

            _controllerPage.Button_Exit.Click += Button_Exit_Click;
        }

        void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            _controller.GoToUserRegistrationPage();
        }

        public void SetupToWindow()
        {
            _controllerWindow.Content = _controllerPage;

            _controllerPage.Label_ResultInfo.Content = _controller.Test.GetReport();
        }
    }
}
