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
    class UserRegistrationController : IPageController
    {
        private UserRegistration _controllerPage;
        private Window _controllerWindow;
        private MainPageController _controller;

        public UserRegistration ControllerPage
        {
            get { return _controllerPage; }
        }

        public Window ControllerWindow
        {
            get { return _controllerWindow; }
        }

        public UserRegistrationController(Window window, MainPageController controller)
        {
            _controllerWindow = window;
            _controller = controller;

            _controllerPage = new UserRegistration();

            _controllerPage.Button_Continue.Click += Button_Continue_Click;
        }

        void Button_Continue_Click(object sender, RoutedEventArgs e)
        {
            _controller.GoToUserIntroductionPage();
            //throw new NotImplementedException();
        }

        public void SetupToWindow()
        {
            _controllerWindow.Content = _controllerPage;
        }
    }
}
