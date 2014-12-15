using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DesktopClient.Pages;

namespace DesktopClient.PageControlles
{
    class StatisticsController : IPageController
    {
        private readonly Statistic _controllerPage;
        private readonly Window _controllerWindow;
        private readonly MainPageController _controller;

        public Statistic ControllerPage
        {
            get { return _controllerPage; }
        }

        public Window ControllerWindow
        {
            get { return _controllerWindow; }
        }

        public StatisticsController(Window window, MainPageController controller)
        {
            _controllerWindow = window;
            _controller = controller;

            _controllerPage = new Statistic();

            _controllerPage.Button_Back.Click += Button_Back_Click;
        }

        void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            _controller.GoToUserRegistrationPage();
        }

        public void SetupToWindow()
        {
            _controllerWindow.Content = _controllerPage;
        }
    }
}
