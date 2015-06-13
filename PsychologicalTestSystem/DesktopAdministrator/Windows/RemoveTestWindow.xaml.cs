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
    /// Interaction logic for RemoveTestWindow.xaml
    /// </summary>
    public partial class RemoveTestWindow : Window
    {
        private readonly ITestingRepository _repository;
        private readonly MainWindow _mainWindow;

        public RemoveTestWindow(MainWindow mainWindow, ITestingRepository repository)
        {
            InitializeComponent();

            _repository = repository;
            _mainWindow = mainWindow;


            var tests = _repository.GetAllTest();

            ComboBoxTests.Items.Clear();

            foreach (var item in tests)
            {
                ComboBoxTests.Items.Add(item);
            }

            if (tests.Count() != 0)
            {
                ComboBoxTests.SelectedIndex = 0;
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            var test = ComboBoxTests.SelectedItem as Test;

            _repository.RemoveTest(test.Id);

            _mainWindow.UpdateTestTable();
            _mainWindow.UpdateComboBoxTestStatistic();
            _mainWindow.UpdateComboBoxAvailableTests();
            _mainWindow.UpdateComboBoxProblemTests();

            this.Hide();
        }
    }
}
