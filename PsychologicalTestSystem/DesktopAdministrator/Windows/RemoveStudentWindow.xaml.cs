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
    /// Interaction logic for RemoveStudentWindow.xaml
    /// </summary>
    public partial class RemoveStudentWindow : Window
    {
        private readonly ITestingRepository _repository;
        private readonly MainWindow _mainWindow;

        public RemoveStudentWindow(MainWindow mainWindow, ITestingRepository repository)
        {
            InitializeComponent();

            _repository = repository;
            _mainWindow = mainWindow;

            var groups = _repository.GetAllGroup();

            ComboboxGroups.Items.Clear();

            foreach (var item in groups)
            {
                ComboboxGroups.Items.Add(item);
            }

            if (groups.Count() != 0)
            {
                ComboboxGroups.SelectedIndex = 0;
            }

            InitComboBoxStudents();
        }

        void InitComboBoxStudents()
        {
            var group = ComboboxGroups.SelectedItem as Group;

            if (group == null)
            {
                return;
            }

            var studets = _repository.GetUserByGroup(group.Id);

            ComboboxStudents.Items.Clear();

            foreach (var item in studets)
            {
                ComboboxStudents.Items.Add(item);
            }

            if (studets.Count() != 0)
            {
                ComboboxStudents.SelectedIndex = 0;
            }
        }

        private void ComboboxGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitComboBoxStudents();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();            
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            var student = ComboboxStudents.SelectedItem as User;

            _repository.RemoveUser(student.Id);

            this.Hide();         
        }
    }
}
