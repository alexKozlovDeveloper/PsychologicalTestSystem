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

            InitTable();
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

                var toReport = (testingReport.ChekedAnswer == 1)
                    ? question.FirstReportMessage
                    : (testingReport.ChekedAnswer == 2) ? question.SecondReportMessage : question.ThirdReportMessage;

                entity.Add(new TestingReport
                {
                    Message = question.Message,
                    Answer = answer,
                    ToReport = toReport
                });
            }

            DataGridTestingReport.ItemsSource = entity;
        }
    }
}
