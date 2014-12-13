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
    class UserTestController : IPageController
    {
        private UserTest _controllerPage;
        private Window _controllerWindow;
        private MainPageController _controller;

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
        }

        void Button_Yes_Click(object sender, RoutedEventArgs e)
        {
            _controller.GoToTestResultPage();
            //throw new NotImplementedException();
        }

        void Button_Sometimes_Click(object sender, RoutedEventArgs e)
        {
            _controller.GoToTestResultPage();
            //throw new NotImplementedException();
        }

        void Button_No_Click(object sender, RoutedEventArgs e)
        {
            _controller.GoToTestResultPage();
            //throw new NotImplementedException();
        }

        public void SetupToWindow()
        {
            _controllerWindow.Content = _controllerPage;
        }
    }
}
