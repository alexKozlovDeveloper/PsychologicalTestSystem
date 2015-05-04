using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Db.Core.TableEntityes;
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

            _controllerPage.ButtonRegistration.Click += ButtonRegistration_Click;
            _controllerPage.ButtonCancel.Click += ButtonCancel_Click;

            _controllerPage.ComboBoxGroups.Items.Clear();

            var groups = _controller.Repository.GetAllGroup();

            foreach (var group in groups)
            {
                _controllerPage.ComboBoxGroups.Items.Add(group);
            }
        }

        void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            _controller.GoToUserChoicePage();
        }

        void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            var firstName = _controllerPage.TextBox_UserName.Text;
            var lastName = _controllerPage.TextBox_UserLastname.Text;
            var group = _controllerPage.ComboBoxGroups.SelectedItem as Group;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Поля 'Имя' и 'Фамилия' не должны быть пустыми");
                return;
            }

            _controller.Repository.AddUser(firstName, lastName, group.Id);

            _controller.GoToUserChoicePage();
        }

        public void SetupToWindow()
        {
            _controllerWindow.Content = _controllerPage;
        }
    }
}
