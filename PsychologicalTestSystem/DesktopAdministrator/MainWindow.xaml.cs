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

            
            //var count = 75;

            //var rnd = new Random();

            //_chart.AddItem(new TestingChartItem { AveragePercent = 0, Number = 0, HighPercent = 0 });
            //_chart.AddItem(new TestingChartItem { AveragePercent = 1, Number = 0, HighPercent = 1 });
            //_chart.AddItem(new TestingChartItem { AveragePercent = 2, Number = 0, HighPercent = 2 });
            //_chart.AddItem(new TestingChartItem { AveragePercent = 3, Number = 0, HighPercent = 3 });
            //_chart.AddItem(new TestingChartItem { AveragePercent = 4, Number = 0, HighPercent = 4 });
            //_chart.AddItem(new TestingChartItem { AveragePercent = 5, Number = 0, HighPercent = 5 });
            //_chart.AddItem(new TestingChartItem { AveragePercent = 100, Number = 0, HighPercent = 100 });

            //for (int i = 0; i < count; i++)
            //{
            //    var t = new TestingChartItem
            //    {
            //        AveragePercent = rnd.Next(0, 100),
            //        HighPercent = rnd.Next(0, 100),
            //        Number = i
            //    };

            //    _chart.AddItem(t);
            //}

            InitComboBoxTestStatistic();

            InitDataGridIncludeGroups();

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

        private void InitDataGridIncludeGroups()
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

        private void InitComboBoxTestStatistic()
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

        private void InitWindowElements()
        {
            SetGroupTable();
            SetTestTable();
            SetTestingTable();
            SetComboBoxAvailableTests();
            SetAvailableGroupsTable();
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

        private void ComboBoxAvailableTests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetAvailableGroupsTable();
        }

        private void SetTestingTable()
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

                entity.Add(new TestingUser
                {
                    Date = passingTest.Date,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    GroupNumber = group.Number,
                    PassingTestId = passingTest.Id
                });
            }

            DataGridTesting.ItemsSource = entity;
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

        private void SetAvailableGroupsTable()
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

        private void ShowTestingDetails(object sender, RoutedEventArgs e)
        {
            var item = DataGridTesting.SelectedItem as TestingUser;

            if (item == null)
            {
                return;
            }

            _showTestingDetailsWindow = new ShowTestingDetailsWindow(this, _repository, item.PassingTestId);

            _showTestingDetailsWindow.Show();
        }

        private void ButtonWriteDbToXml_Click(object sender, RoutedEventArgs e)
        {
            _repository.WriteToFolder(ConfigurationManager.AppSettings[ConfigKeys.WorkFolderKey]);
        }

        private void ButtonReadFromXml_Click(object sender, RoutedEventArgs e)
        {
            _repository.ReadFromFolder(ConfigurationManager.AppSettings[ConfigKeys.WorkFolderKey]);
        }

        private void ButtonRemoveGroup_Click(object sender, RoutedEventArgs e)
        {
            _removeGroupWindow = new RemoveGroupWindow(this, _repository);

            _removeGroupWindow.Show();
        }

        private void ButtonRemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            _removeStudentWindow = new RemoveStudentWindow(this, _repository);

            _removeStudentWindow.Show();
        }

        private void ButtonRemoveTest_Click(object sender, RoutedEventArgs e)
        {
            _removeTestWindow = new RemoveTestWindow(this, _repository);

            _removeTestWindow.Show();
        }

        private void ButtonRemoveQuestionFromTest_Click(object sender, RoutedEventArgs e)
        {
            _removeQuestionFromTestWindow = new RemoveQuestionFromTestWindow(this, _repository);

            _removeQuestionFromTestWindow.Show();
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

        private void ButtonRemoveQuestion_Click(object sender, RoutedEventArgs e)
        {
            _removeQuestionFromTestWindow = new RemoveQuestionFromTestWindow(this, _repository);

            _removeQuestionFromTestWindow.Show();
        }
    }
}
