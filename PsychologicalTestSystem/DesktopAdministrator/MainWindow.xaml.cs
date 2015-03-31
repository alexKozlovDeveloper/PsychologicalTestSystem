using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DbController.Repositoryes;
using DbController.TableEntityes;
using DesktopAdministrator.Windows;
using TcpServerLogic;

namespace DesktopAdministrator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TestTcpServer _server;
        private readonly ITestingRepository _repository;

        private AddGroupWindow _addGroupWindow;
        private AddUserWindow _addUserWindow;

        public MainWindow()
        {
            InitializeComponent();

            _server = new TestTcpServer();
            _repository = new TestingRepository();

            InitWindowElements();
        }

        private void InitWindowElements()
        {
            SetGroupTable();
        }

        public void AddGroupToComboBox(Group group)
        {
            ComboBoxGroups.Items.Add(group);
        }

        private void SetGroupTable()
        {
            var groups = _repository.GetAllGroup();

            ComboBoxGroups.Items.Clear();

            foreach (var group in groups)
            {
                ComboBoxGroups.Items.Add(group);
            }

            ComboBoxGroups.SelectedIndex = 0;

            var selectedGroup = ComboBoxGroups.SelectedItem as Group;

            SetStudentTable(selectedGroup);
        }

        private void SetStudentTable(Group group)
        {
            var students = _repository.GetUserByGroup(group.Id);

            TextBoxStudents.Clear();

            foreach (var student in students)
            {
                var str = string.Format("{0} {1}", student.FirstName, student.LastName);

                TextBoxStudents.Text += str + Environment.NewLine;
            }
        }

        private void StartServerButton_Click(object sender, RoutedEventArgs e)
        {
            _server.Start();
        }

        private void ComboBoxGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedGroup = ComboBoxGroups.SelectedItem as Group;

            SetStudentTable(selectedGroup);
        }

        private void ButtonAddGroup_Click(object sender, RoutedEventArgs e)
        {
            _addGroupWindow = new AddGroupWindow(this, _repository);

            _addGroupWindow.Show();
        }

        private void ButtonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            _addUserWindow = new AddUserWindow(_repository);

            _addUserWindow.Show();
        }


    }
}
