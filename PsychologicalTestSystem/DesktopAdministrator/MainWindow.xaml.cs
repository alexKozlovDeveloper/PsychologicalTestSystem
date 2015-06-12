using System;
using System.Collections.Generic;
using System.IO;
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
using Db.Core.Loading;
using Db.Core.Repositoryes;
using Db.Core.TableEntityes;
using DesktopAdministrator.DataGridEntityes;
using DesktopAdministrator.Helpers;
using DesktopAdministrator.Windows;
using TcpServerLogic;
using System.Configuration;
using Helpers.Keys;
using Db.Core.Statistic;
using System.Threading;

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
        private ShowTestingDetailsWindow _showTestingDetailsWindow;
        private RemoveStudentWindow _removeStudentWindow;
        private RemoveGroupWindow _removeGroupWindow;
        private RemoveQuestionFromTestWindow _removeQuestionFromTestWindow;
        private RemoveTestWindow _removeTestWindow;
        private RemovePassingTestWindow _removePassingTestWindow;

        private TestingChart _chart;

        private bool _isWork;
        private Thread _updateThread;

        private List<AvailableGroups> entityAvailableGroups;
        private List<AvailableGroups> entityIncludeGroups;

        private Test selectedTestToStatistic;

        public MainWindow()
        {
            InitializeComponent();

            _isWork = true;

            _server = new TestTcpServer();
            _repository = new TestingRepository();

            InitWindowElements();

            _chart = new TestingChart(GridStatistic);

            UpdateComboBoxTestStatistic();
            UpdateDataGridIncludeGroups();

            _updateThread = new Thread(UpdateDbAvailableGroup);

            _updateThread.Start();

            this.Closed += MainWindow_Closed;
        }

        void MainWindow_Closed(object sender, EventArgs e)
        {
            _isWork = false;
        }        

        private void UpdateDbAvailableGroup()
        {
            while (_isWork)
            {
                Thread.Sleep(100);

                try                 
                {
                    foreach (var item in entityAvailableGroups)
                    {
                        if (item.IsAvailable == true)
                        {
                            _repository.AddAvailableGroup(item.GroupId, item.TestId);
                        }
                        else
                        {
                            _repository.RemoveAvailableGroup(item.GroupId, item.TestId);
                        }
                    }
                }
                catch (Exception ex)
                { 
                
                }

                //Thread.Sleep(1000);

                //if (entityIncludeGroups != null)
                //{
                //    _chart.Clear();

                //    var sh = new StatisticHelper(_repository);

                //    var test = ggwp;//ComboBoxTestsOnStatistics.SelectedItem as Test;

                //    var ids = new List<Guid>();

                //    foreach (var item in entityIncludeGroups)
                //    {
                //        if (item.IsAvailable == true)
                //        {
                //            ids.Add(item.GroupId);
                //        }
                //    }

                //    var statistic = sh.GetGroupStatistic(ids, test.Id);

                //    foreach (var item in statistic)
                //    {
                //        _chart.AddItem(item);
                //    }
                //}
            }
        }
        
        private void StartServerButton_Click(object sender, RoutedEventArgs e)
        {
            _server.Start();
        }

        private void ComboBoxGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedGroup = ComboBoxGroups.SelectedItem as Group;

            UpdateStudentTable(selectedGroup);
        }

        private void ComboBoxTests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateQuestionTable();
        }

        private void ComboBoxAvailableTests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAvailableGroupsTable();
        }

        private void SetComboBoxAvailableTests()
        {
            var tests = _repository.GetAllTest();

            ComboBoxAvailableTests.Items.Clear();

            foreach (var test in tests)
            {
                ComboBoxAvailableTests.Items.Add(test);
            }

            ComboBoxAvailableTests.SelectedIndex = 0;
        }

        private void ButtonWriteDbToXml_Click(object sender, RoutedEventArgs e)
        {
            _repository.WriteToFolder(ConfigurationManager.AppSettings[ConfigKeys.WorkFolderKey]);
        }

        private void ButtonReadFromXml_Click(object sender, RoutedEventArgs e)
        {
            _repository.ReadFromFolder(ConfigurationManager.AppSettings[ConfigKeys.WorkFolderKey]);
        }

        private void ComboBoxTestsOnStatistics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _chart.Clear();

            var sh = new StatisticHelper(_repository);

            var test = ComboBoxTestsOnStatistics.SelectedItem as Test;

            var groups = _repository.GetAllGroup();

            var ids = new List<Guid>();

            foreach (var item in groups)
            {
                ids.Add(item.Id);
            }

            var statistic = sh.GetGroupStatistic(ids, test.Id);

            foreach (var item in statistic)
            {
                _chart.AddItem(item);
            }

            selectedTestToStatistic = ComboBoxTestsOnStatistics.SelectedItem as Test;
        }

        private void ButtonUpdateStatistic_Click(object sender, RoutedEventArgs e)
        {
            _chart.Clear();

            var sh = new StatisticHelper(_repository);

            var test = selectedTestToStatistic;

            var ids = new List<Guid>();

            foreach (var item in entityIncludeGroups)
            {
                if (item.IsAvailable == true)
                {
                    ids.Add(item.GroupId);
                }
            }

            var statistic = sh.GetGroupStatistic(ids, test.Id);

            foreach (var item in statistic)
            {
                _chart.AddItem(item);
            }
        }

        #region UpdateWindowsElements
        public void AddGroupToComboBox(Group group)
        {
            ComboBoxGroups.Items.Add(group);
        }

        public void AddTestToComboBox(Test test)
        {
            ComboBoxTests.Items.Add(test);
        }

        public void InitWindowElements()
        {
            UpdateGroupTable();
            UpdateTestTable();
            UpdateTestingTable();
            SetComboBoxAvailableTests();
            UpdateAvailableGroupsTable();
        }

        public void UpdateAllWindowItems()
        {
            //UpdateDataGridIncludeGroups();
            //UpdateComboBoxTestStatistic();
            //UpdateGroupTable();
            //UpdateTestTable();
            //UpdateQuestionTable();
            //UpdateStudentTable();
            //UpdateStudentTable();
            //SetComboBoxAvailableTests();
            //UpdateAvailableGroupsTable();
            //UpdateTestTable();
            //UpdateTestingTable();
            //SetComboBoxAvailableTests();
            //UpdateAvailableGroupsTable();
            //UpdateTestTable();
            //UpdateTestingTable();
            //SetComboBoxAvailableTests();
            //UpdateAvailableGroupsTable();
        }

        public void UpdateDataGridIncludeGroups()
        {
            var groups = _repository.GetAllGroup();

            entityIncludeGroups = new List<AvailableGroups>();

            var test = ComboBoxAvailableTests.SelectedItem as Test;

            foreach (var group in groups)
            {
                var isAvailable = true;

                entityIncludeGroups.Add(new AvailableGroups { GroupName = group.Number, IsAvailable = isAvailable, GroupId = group.Id, TestId = test.Id });
            }

            DataGridIncludeGroups.ItemsSource = entityIncludeGroups;
        }

        public void UpdateComboBoxTestStatistic()
        {
            ComboBoxTestsOnStatistics.Items.Clear();

            var tests = _repository.GetAllTest();

            foreach (var item in tests)
            {
                ComboBoxTestsOnStatistics.Items.Add(item);
            }

            if (ComboBoxTestsOnStatistics.Items.Count != 0)
            {
                ComboBoxTestsOnStatistics.SelectedIndex = 0;
                selectedTestToStatistic = ComboBoxTestsOnStatistics.SelectedItem as Test;
            }
        }

        public void UpdateGroupTable()
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

        public void UpdateTestTable()
        {
            var tests = _repository.GetAllTest();

            ComboBoxTests.Items.Clear();

            ComboBoxTests.Items.Add(new Test { Name = "All" });

            foreach (var test in tests)
            {
                ComboBoxTests.Items.Add(test);
            }

            ComboBoxTests.SelectedIndex = 0;

            var item = ComboBoxTests.SelectedItem as Test;

            UpdateQuestionTable(item);
        }

        public void UpdateQuestionTable()
        {
            var selectedTest = ComboBoxTests.SelectedItem as Test;

            UpdateQuestionTable(selectedTest);
        }

        public void UpdateStudentTable()
        {
            var selectedGroup = ComboBoxGroups.SelectedItem as Group;

            UpdateStudentTable(selectedGroup);
        }

        public void UpdateStudentTable(Group group)
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

        public void UpdateQuestionTable(Test test)
        {
            List<Question> questions = new List<Question>();

            if (test.Name == "All")
            {
                questions = _repository.GetAllQuestion().ToList();
            }
            else
            {
                questions = _repository.GetQuestions(test.Id).ToList();
            }

            questions.Sort();

            var src = ConvertHelper.ConvertCollection<QuestionEntity, Question>(questions);

            DataGridQuestion.ItemsSource = src;
        }

        public void UpdateTestingTable()
        {
            var testing = _repository.GetAllPassingTest();

            var entity = new List<TestingUser>();

            foreach (var passingTest in testing)
            {
                var user = _repository.GetUser(passingTest.UserId);

                if (user == null)
                {
                    MessageBox.Show("Не найден пользователь с идентификатором " + passingTest.UserId);
                    continue;
                }

                var group = _repository.GetGroup(user.GroupId);

                var test = _repository.GetTest(passingTest.TestId);

                entity.Add(new TestingUser
                {
                    Date = passingTest.Date,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    GroupNumber = group.Number,
                    PassingTestId = passingTest.Id,
                    TestName = test.Name
                });
            }

            entity.Sort();

            DataGridTesting.ItemsSource = entity;
        }

        public void UpdateAvailableGroupsTable()
        {
            var selectedTest = ComboBoxAvailableTests.SelectedItem as Test;

            if (selectedTest == null)
            {
                return;
            }

            var groups = _repository.GetAllGroup();

            entityAvailableGroups = new List<AvailableGroups>();

            var test = ComboBoxAvailableTests.SelectedItem as Test;

            foreach (var group in groups)
            {
                var isAvailable = _repository.IsAvailableGroup(selectedTest.Id, group.Id);

                entityAvailableGroups.Add(new AvailableGroups { GroupName = group.Number, IsAvailable = isAvailable, TestId = test.Id, GroupId = group.Id });
            }

            DataGridAvailableGroups.ItemsSource = entityAvailableGroups;
        }
        #endregion

        #region CreateNewWindow  
        private void ButtonRemoveQuestionFromTest_Click(object sender, RoutedEventArgs e)
        {
            _removeQuestionFromTestWindow = new RemoveQuestionFromTestWindow(this, _repository);

            _removeQuestionFromTestWindow.ShowDialog();
        }

        private void ButtonRemoveTest_Click(object sender, RoutedEventArgs e)
        {
            _removeTestWindow = new RemoveTestWindow(this, _repository);

            _removeTestWindow.ShowDialog();
        }

        private void ButtonRemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            _removeStudentWindow = new RemoveStudentWindow(this, _repository);

            _removeStudentWindow.ShowDialog();
        }
        
        private void ButtonRemoveGroup_Click(object sender, RoutedEventArgs e)
        {
            _removeGroupWindow = new RemoveGroupWindow(this, _repository);

            _removeGroupWindow.ShowDialog();
        }

        private void ShowTestingDetails(object sender, RoutedEventArgs e)
        {
            var item = DataGridTesting.SelectedItem as TestingUser;

            if (item == null)
            {
                return;
            }

            _showTestingDetailsWindow = new ShowTestingDetailsWindow(this, _repository, item.PassingTestId);

            _showTestingDetailsWindow.ShowDialog();
        }

        private void ButtonAddGroup_Click(object sender, RoutedEventArgs e)
        {
            _addGroupWindow = new AddGroupWindow(this, _repository);

            _addGroupWindow.ShowDialog();
        }

        private void ButtonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            _addUserWindow = new AddUserWindow(this, _repository);

            _addUserWindow.ShowDialog();
        }

        private void ButtonAddTest_Click(object sender, RoutedEventArgs e)
        {
            _addTestWindow = new AddTestWindow(this, _repository);

            _addTestWindow.ShowDialog();
        }

        private void ButtonAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            _addQuestionWindow = new AddQuestionWindow(this, _repository);

            _addQuestionWindow.ShowDialog();
        }

        private void ButtonAddQuestionToTest_Click(object sender, RoutedEventArgs e)
        {
            _addQuestionToTestWindow = new AddQuestionToTestWindow(this, _repository);

            _addQuestionToTestWindow.ShowDialog();
        }

        private void ButtonRemoveQuestion_Click(object sender, RoutedEventArgs e)
        {
            _removeQuestionFromTestWindow = new RemoveQuestionFromTestWindow(this, _repository);

            _removeQuestionFromTestWindow.ShowDialog();
        }

        private void ButtonRemovePassingTest_Click(object sender, RoutedEventArgs e)
        {
            _removePassingTestWindow = new RemovePassingTestWindow(this, _repository);

            _removePassingTestWindow.ShowDialog();
        }
        #endregion
    }
}
