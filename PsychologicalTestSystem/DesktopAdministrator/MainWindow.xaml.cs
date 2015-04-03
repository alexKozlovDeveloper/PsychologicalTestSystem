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
using Db.Core.Convert;
using Db.Core.Repositoryes;
using Db.Core.TableEntityes;
using DesktopAdministrator.DataGridEntityes;
using DesktopAdministrator.Helpers;
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

            UpdateStudentTable();
        }

        private void SetTestTable()
        {
            var tests = _repository.GetAllTest();

            ComboBoxTests.Items.Clear();

            ComboBoxTests.Items.Add(new Test {Name = "All"});

            foreach (var test in tests)
            {
                ComboBoxTests.Items.Add(test);
            }

            ComboBoxTests.SelectedIndex = 0;

            var item = ComboBoxTests.SelectedItem as Test;

            SetQuestionTable(item);
        }

        public void UpdateQuestionTable()
        {
            var selectedTest = ComboBoxTests.SelectedItem as Test;

            SetQuestionTable(selectedTest);
        }

        public void UpdateStudentTable()
        {
            var selectedGroup = ComboBoxGroups.SelectedItem as Group;

            SetStudentTable(selectedGroup);
        }

        private void SetStudentTable(Group group)
        {
            if (group == null)
            {
                return;
            }

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
            IEnumerable<Question> questions = new List<Question>();

            if (test.Name == "All")
            {
                questions = _repository.GetAllQuestion();
            }
            else
            {
                questions = _repository.GetQuestions(test);
            }
            
            var src = ConvertHelper.ConvertCollection<QuestionEntity, Question>(questions);

            DataGridQuestion.ItemsSource = src;
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
            _addUserWindow = new AddUserWindow(this, _repository);

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

        private void ComboBoxTests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateQuestionTable();
        }
    }
}
