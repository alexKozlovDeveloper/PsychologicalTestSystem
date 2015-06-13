using Db.Core.Repositoryes;
using Db.Core.TableEntityes;
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

namespace DesktopAdministrator.Windows
{
    /// <summary>
    /// Interaction logic for RemoveQuestionWindow.xaml
    /// </summary>
    public partial class RemoveQuestionWindow : Window
    {
        private readonly ITestingRepository _repository;
        private readonly MainWindow _mainWindow;

        public RemoveQuestionWindow(MainWindow mainWindow, ITestingRepository repository)
        {
            InitializeComponent();

            _repository = repository;
            _mainWindow = mainWindow;

            var quests = _repository.GetAllQuestion();

            foreach (var item in quests)
            {
                ComboBoxQuestions.Items.Add(item);
            }

            if (ComboBoxQuestions.Items.Count != 0)
            {
                ComboBoxQuestions.SelectedIndex = 0;
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            var ques = ComboBoxQuestions.SelectedItem as Question;

            _repository.RemoveQuestion(ques.Id);

            _mainWindow.UpdateQuestionTable();
            _mainWindow.UpdateComboBoxProblemQuestions();

            this.Hide();
        }
    }
}
