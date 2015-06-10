using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Db.Core.Loading;
using Db.Core.TableEntityes;
using DesktopClient.Conf;
using DesktopClient.Pages;
using System.IO;
using System.Configuration;
using Helpers.Keys;

namespace DesktopClient.PageControlles
{
    class UserChoiceController : IPageController
    {
        private readonly UserChoice _controllerPage;
        private readonly Window _controllerWindow;
        private readonly MainPageController _controller;

        public UserChoiceController(Window window, MainPageController controller)
        {
            _controllerWindow = window;
            _controller = controller;

            _controllerPage = new UserChoice();

            var groups = _controller.Repository.GetAllGroup();

            foreach (var group in groups)
            {
                _controllerPage.ComboBoxGroups.Items.Add(group);
            }

            _controllerPage.ComboBoxGroups.SelectedIndex = 0;

            InitComboBoxUsers();

            _controllerPage.ComboBoxGroups.SelectionChanged += ComboBoxGroups_SelectionChanged;
            _controllerPage.ButtonRegistration.Click += ButtonRegistration_Click;
            _controllerPage.ButtonContinue.Click += ButtonContinue_Click;
            _controllerPage.ButtonExit.Click += ButtonExit_Click;
            //_controllerPage.ButtonWriteInFolder.Click += ButtonWriteInFolder_Click;
            _controllerPage.CheckBoxDbConnect.Checked += CheckBoxDbConnect_Checked;
            _controllerPage.CheckBoxDbConnect.Unchecked += CheckBoxDbConnect_Unchecked;
        }

        void CheckBoxDbConnect_Unchecked(object sender, RoutedEventArgs e)
        {
            _controller.ConnectToLocalFolder();
        }

        void CheckBoxDbConnect_Checked(object sender, RoutedEventArgs e)
        {
            _controller.ConnectToLocalDb();
        }

        //void ButtonWriteInFolder_Click(object sender, RoutedEventArgs e)
        //{
        //    _controller.Repository.WriteToFolder(ConfigurationManager.AppSettings[ConfigKeys.WorkFolderKey]);
        //}

        void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            _controller.Exit();
        }

        void ButtonContinue_Click(object sender, RoutedEventArgs e)
        {
            AppConfig.CurrentUser = _controllerPage.ComboBoxUsers.SelectedItem as User;
            AppConfig.CurrenGroup = _controllerPage.ComboBoxGroups.SelectedItem as Group;

            _controller.GoToTestChoicePage();
        }

        void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            _controller.GoToUserRegistrationPage();
        }

        void ComboBoxGroups_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            InitComboBoxUsers();
        }

        private void InitComboBoxUsers()
        {
            _controllerPage.ComboBoxUsers.Items.Clear();

            var group = _controllerPage.ComboBoxGroups.SelectedItem as Group;

            var users = _controller.Repository.GetUserByGroup(group.Id);

            foreach (var user in users)
            {
                _controllerPage.ComboBoxUsers.Items.Add(user);
            }

            _controllerPage.ComboBoxUsers.SelectedIndex = 0;
        }

        public System.Windows.Window ControllerWindow
        {
            get { return _controllerWindow; }
        }

        public void SetupToWindow()
        {
            _controllerWindow.Content = _controllerPage;
        }
    }
}
