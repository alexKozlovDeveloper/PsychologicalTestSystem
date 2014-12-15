using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DesktopClient.Pages;

namespace DesktopClient.PageControlles
{
    class AdministratorLoginController : IPageController
    {
        private AdministratorLogin _controllerPage;
        private Window _controllerWindow;
        private MainPageController _controller;

        public AdministratorLogin ControllerPage
        {
            get { return _controllerPage; }
        }

        public Window ControllerWindow
        {
            get { return _controllerWindow; }
        }

        public AdministratorLoginController(Window window, MainPageController controller)
        {
            _controllerWindow = window;
            _controller = controller;

            _controllerPage = new AdministratorLogin();

            _controllerPage.Button_Continue.Click += Button_Continue_Click;
            _controllerPage.Button_Back.Click += Button_Back_Click;
        }

        void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            _controller.GoToUserRegistrationPage();
        }

        void Button_Continue_Click(object sender, RoutedEventArgs e)
        {
            _controller.GoToStatisticsPage();
        }

        public void SetupToWindow()
        {
            _controllerWindow.Content = _controllerPage;
        }
    }
}
