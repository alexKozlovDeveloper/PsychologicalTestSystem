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
using DbController.Repositoryes;

namespace DesktopAdministrator.Windows
{
    /// <summary>
    /// Interaction logic for AddTestWindow.xaml
    /// </summary>
    public partial class AddTestWindow : Window
    {
        private readonly ITestingRepository _repository;
        private readonly MainWindow _mainWindow;

        public AddTestWindow(MainWindow mainWindow, ITestingRepository repository)
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
            var testName = TextBoxTestName.Text;

            var test = _repository.AddTest(testName);

            _mainWindow.AddTestToComboBox(test);

            this.Hide();
        }
    }
}
