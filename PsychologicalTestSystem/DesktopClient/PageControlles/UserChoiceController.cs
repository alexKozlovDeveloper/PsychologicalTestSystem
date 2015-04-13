using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopClient.PageControlles
{
    class UserChoiceController : IPageController
    {
        private readonly Window _controllerWindow;
        private readonly MainPageController _controller;

        public UserChoiceController(Window window, MainPageController controller)
        {
            _controllerWindow = window;
            _controller = controller;
        }

        public System.Windows.Window ControllerWindow
        {
            get { throw new NotImplementedException(); }
        }

        public void SetupToWindow()
        {
            throw new NotImplementedException();
        }
    }
}
