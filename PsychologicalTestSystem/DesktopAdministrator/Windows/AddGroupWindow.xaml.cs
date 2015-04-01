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
    /// Interaction logic for AddGroupWindow.xaml
    /// </summary>
    public partial class AddGroupWindow : Window
    {
        private readonly ITestingRepository _repository;
        private readonly MainWindow _mainWindow;

        public AddGroupWindow(MainWindow mainWindow, ITestingRepository repository)
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
            var groupnumber = TextBoxGroupNumber.Text;

            var group = _repository.AddGroup(groupnumber);

            _mainWindow.AddGroupToComboBox(group);

            this.Hide();
        }
    }
}
