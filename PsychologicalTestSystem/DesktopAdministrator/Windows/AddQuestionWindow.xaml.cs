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

namespace DesktopAdministrator.Windows
{
    /// <summary>
    /// Interaction logic for AddQuestionWindow.xaml
    /// </summary>
    public partial class AddQuestionWindow : Window
    {
        private readonly ITestingRepository _repository;
        private readonly MainWindow _mainWindow;

        public AddQuestionWindow(MainWindow mainWindow, ITestingRepository repository)
        {
            InitializeComponent();

            _repository = repository;
            _mainWindow = mainWindow;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var question = TextBoxQuestion.Text;

            var answer1 = TextBoxAnswer1.Text;
            var answer2 = TextBoxAnswer2.Text;
            var answer3 = TextBoxAnswer3.Text;

            var report1 = TextBoxReport1.Text;
            var report2 = TextBoxReport2.Text;
            var report3 = TextBoxReport3.Text;

            _repository.AddQuestion(question, answer1, answer2, answer3, report1, report2, report3);

            this.Hide();
        }
    }
}
