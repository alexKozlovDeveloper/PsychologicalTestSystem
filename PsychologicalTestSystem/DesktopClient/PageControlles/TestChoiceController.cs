using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopClient.PageControlles
{
    class TestChoiceController : IPageController
    {
        private readonly Window _controllerWindow;
        private readonly MainPageController _controller;

        public TestChoiceController(Window window, MainPageController controller)
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
