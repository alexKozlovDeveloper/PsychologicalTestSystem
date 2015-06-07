using Db.Core.Repositoryes;
using Db.Core.TableEntityes;
using DesktopAdministrator.DataGridEntityes;
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
    /// Interaction logic for RemoveQuestionFromTestWindow.xaml
    /// </summary>
    public partial class RemoveQuestionFromTestWindow : Window
    {
        private readonly ITestingRepository _repository;
        private readonly MainWindow _mainWindow;

        public RemoveQuestionFromTestWindow(MainWindow mainWindow, ITestingRepository repository)
        {
            InitializeComponent();

            _repository = repository;
            _mainWindow = mainWindow;

            var qTot = _repository.GetAllQuestionToTest();

            ComboBoxQuestionToTest.Items.Clear();

            foreach (var item in qTot)
            {
                var obj = new QuestionToTestInfo
                {
                    Id = item.Id,
                    Message = QuestionToTestInfo.GetMessage(_repository,item)
                };

                ComboBoxQuestionToTest.Items.Add(obj);
            }

            if (qTot.Count() != 0)
            {
                ComboBoxQuestionToTest.SelectedIndex = 0;
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();  
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            var qTot = ComboBoxQuestionToTest.SelectedItem as QuestionToTestInfo;

            _repository.RemoveQuestionToTest(qTot.Id);

            this.Hide();  
        }
    }
}
