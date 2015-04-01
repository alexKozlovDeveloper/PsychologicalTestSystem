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
using Db.Core.Repositoryes;
using Db.Core.TableEntityes;
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
        private AddTestWindow _addTestWindow;
        private AddQuestionWindow _addQuestionWindow;
        private AddQuestionToTestWindow _addQuestionToTestWindow;

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
            SetTestTable();
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

        private void SetTestTable()
        {
            var tests = _repository.GetAllTest();

            ComboBoxTests.Items.Clear();

            foreach (var test in tests)
            {
                ComboBoxTests.Items.Add(test);
            }

            ComboBoxTests.SelectedIndex = 0;

            var selectedTest = ComboBoxTests.SelectedItem as Test;

            SetQuestionTable(selectedTest);
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

        private void SetQuestionTable(Test test)
        {
            //var q1 = _repository.AddQuestion("a1", "a2", "a3", "a4", "a5", "a6", "a7");
            //var q2 = _repository.AddQuestion("b1", "b2", "b3", "b4", "b5", "b6", "b7");
            //var q3 = _repository.AddQuestion("c1", "c2", "c3", "c4", "c5", "c6", "c7");


            //_repository.AddQuestionToTest(q1.Id, test.Id);
            //_repository.AddQuestionToTest(q2.Id, test.Id);
            //_repository.AddQuestionToTest(q3.Id, test.Id);

            //DataGridQuestion.ItemsSource = test.Questions;

            //foreach (var question in test.Questions)
            //{

            //}
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

        public void AddTestToComboBox(Test test)
        {
            ComboBoxTests.Items.Add(test);
        }

        private void ButtonAddTest_Click(object sender, RoutedEventArgs e)
        {
            _addTestWindow = new AddTestWindow(this, _repository);

            _addTestWindow.Show();
        }

        private void ButtonAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            _addQuestionWindow = new AddQuestionWindow(this, _repository);

            _addQuestionWindow.Show();
        }

        private void ButtonAddQuestionToTest_Click(object sender, RoutedEventArgs e)
        {
            _addQuestionToTestWindow = new AddQuestionToTestWindow(this, _repository);

            _addQuestionToTestWindow.Show();
        }
    }
}
