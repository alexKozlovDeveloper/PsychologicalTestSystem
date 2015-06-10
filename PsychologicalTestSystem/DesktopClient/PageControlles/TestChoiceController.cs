using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Db.Core.TableEntityes;
using DesktopClient.Conf;
using DesktopClient.Pages;

namespace DesktopClient.PageControlles
{
    class TestChoiceController : IPageController
    {
        private readonly TestChoice _controllerPage;
        private readonly Window _controllerWindow;
        private readonly MainPageController _controller;

        public TestChoiceController(Window window, MainPageController controller)
        {
            _controllerWindow = window;
            _controller = controller;

            _controllerPage = new TestChoice();

            _controllerPage.ComboBoxTests.Items.Clear();            

            _controllerPage.ComboBoxTests.SelectedIndex = 0;

            _controllerPage.ButtonCancel.Click += ButtonCancel_Click;
            _controllerPage.ButtonStart.Click += ButtonStart_Click;
        }

        void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            var test = _controllerPage.ComboBoxTests.SelectedItem as Test;

            //_controller.CurrentTestId = test.Id;

            AppConfig.SelectedTest = _controllerPage.ComboBoxTests.SelectedItem as Test;

            _controller.GoToUserIntroductionPage();
        }

        void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            _controller.GoToUserChoicePage();
        }

        public System.Windows.Window ControllerWindow
        {
            get { return _controllerWindow; }
        }

        public void SetupToWindow()
        {
            var tests = _controller.Repository.GetAllTest();

            var currentGroup = AppConfig.CurrenGroup;

            foreach (var test in tests)
            {
                if (_controller.Repository.IsAvailableGroup(test.Id, currentGroup.Id) == true)
                {
                    _controllerPage.ComboBoxTests.Items.Add(test);
                }
            }

            _controllerWindow.Content = _controllerPage;
        }
    }
}
