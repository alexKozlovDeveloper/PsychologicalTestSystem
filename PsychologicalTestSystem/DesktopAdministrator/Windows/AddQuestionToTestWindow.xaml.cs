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
using Db.Core.TableEntityes;

namespace DesktopAdministrator.Windows
{
    /// <summary>
    /// Interaction logic for AddQuestionToTestWindow.xaml
    /// </summary>
    public partial class AddQuestionToTestWindow : Window
    {
        private readonly ITestingRepository _repository;
        private readonly MainWindow _mainWindow;

        public AddQuestionToTestWindow(MainWindow mainWindow, ITestingRepository repository)
        {
            InitializeComponent();

            _repository = repository;
            _mainWindow = mainWindow;

            var tests = _repository.GetAllTest();
            var questions = _repository.GetAllQuestion();

            ComboBoxTest.Items.Clear();

            foreach (var test in tests)
            {
                ComboBoxTest.Items.Add(test);
            }

            ComboBoxQuestion.Items.Clear();

            foreach (var question in questions)
            {
                ComboBoxQuestion.Items.Add(question);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var test = ComboBoxTest.SelectedItem as Test;
            var question = ComboBoxQuestion.SelectedItem as Question;

            _repository.AddQuestionToTest(question.Id, test.Id);

            _mainWindow.UpdateQuestionTable();

            this.Hide();
        }
    }
}
