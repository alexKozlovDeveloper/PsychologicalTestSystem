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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private readonly ITestingRepository _repository;
        private readonly MainWindow _mainWindow;

        public AddUserWindow(MainWindow mainWindow, ITestingRepository repository)
        {
            InitializeComponent();

            _repository = repository;
            _mainWindow = mainWindow;

            var groups = _repository.GetAllGroup();

            ComboBoxGroups.Items.Clear();

            foreach (var group in groups)
            {
                ComboBoxGroups.Items.Add(group);
            }

            ComboBoxGroups.SelectedIndex = 0;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var firsName = TextBoxFirstName.Text;
            var lastName = TextBoxLastName.Text;

            if (string.IsNullOrEmpty(firsName) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Имя и фамилия должны быть заполнены!");
                return;
            }

            var group = ComboBoxGroups.SelectedItem as Group;

            _repository.AddUser(firsName, lastName, group.Id);

            _mainWindow.UpdateStudentTable();

            this.Hide();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
