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
using System.Windows.Shapes;
using Db.Core.Repositoryes;
using DesktopAdministrator.DataGridEntityes;

namespace DesktopAdministrator.Windows
{
    /// <summary>
    /// Interaction logic for ShowTestingDetailsWindow.xaml
    /// </summary>
    public partial class ShowTestingDetailsWindow : Window
    {
        private readonly ITestingRepository _repository;
        private readonly MainWindow _mainWindow;
        private readonly Guid _passingTestId;

        public ShowTestingDetailsWindow(MainWindow mainWindow, ITestingRepository repository, Guid passingTestId)
        {
            InitializeComponent();

            _repository = repository;
            _mainWindow = mainWindow;
            _passingTestId = passingTestId;

            SetWidth();

            this.SizeChanged += ShowTestingDetailsWindow_SizeChanged;
            this.StateChanged += ShowTestingDetailsWindow_StateChanged;

            var passingTest = _repository.GetPassingTest(_passingTestId);
            var user = _repository.GetUser(passingTest.UserId);
            var group = _repository.GetGroup(user.GroupId);

            LabelUserName.Content = string.Format("Студент {0} {1}, группа {2}", user.FirstName, user.LastName, group.Number);

            InitTable();
        }

        void ShowTestingDetailsWindow_StateChanged(object sender, EventArgs e)
        {
            SetWidth();
        }

        void ShowTestingDetailsWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetWidth();
        }

        public void SetWidth()
        {
            DataGridTestingReport.Width = this.Width - 40;
            DataGridTestingReport.Height = this.Height - 120;

            var columnW = this.Width / 3 - 20;

            for (int i = 1; i < DataGridTestingReport.Columns.Count; i++)
            {
                DataGridTestingReport.Columns[i].Width = columnW;
            } 
        }

        private void InitTable()
        {
            var testing = _repository.GetTesting(_passingTestId);

            var entity = new List<TestingReport>();

            foreach (var testingReport in testing)
            {
                var question = _repository.GetQuestion(testingReport.QuestionId);

                var answer = (testingReport.ChekedAnswer == 1)
                    ? question.FirstAnswer
                    : (testingReport.ChekedAnswer == 2) ? question.SecondAnswer : question.ThirdAnswer;

                var toReport = string.Empty;

                if (question.StrongProblemNumber == testingReport.ChekedAnswer)
                {
                    toReport += question.FirstReportMessageToAdmin;
                }

                if (question.WeakProblemNumber == testingReport.ChekedAnswer)
                {
                    toReport += question.SecondReportMessageToAdmin;
                }

                //var toReport = (testingReport.ChekedAnswer == 1)
                //    ? question.FirstReportMessage
                //    : (testingReport.ChekedAnswer == 2) ? question.SecondReportMessage : question.ThirdReportMessage;

                entity.Add(new TestingReport
                {
                    Message = question.Message,
                    Answer = answer,
                    ToReport = toReport,
                    Number = question.SortIndex
                });
            }

            DataGridTestingReport.ItemsSource = entity;
        }
    }
}
