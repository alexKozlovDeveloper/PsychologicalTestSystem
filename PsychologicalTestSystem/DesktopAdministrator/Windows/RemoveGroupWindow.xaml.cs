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
    /// Interaction logic for RemoveGroupWindow.xaml
    /// </summary>
    public partial class RemoveGroupWindow : Window
    {
        private readonly ITestingRepository _repository;
        private readonly MainWindow _mainWindow;

        public RemoveGroupWindow(MainWindow mainWindow, ITestingRepository repository)
        {
            InitializeComponent();

            _repository = repository;
            _mainWindow = mainWindow;

            var groups = _repository.GetAllGroup();

            ComboBoxGroup.Items.Clear();

            foreach (var item in groups)
            {
                ComboBoxGroup.Items.Add(item);
            }

            if (groups.Count() != 0)
            {
                ComboBoxGroup.SelectedIndex = 0;
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            var group = ComboBoxGroup.SelectedItem as Group;

            _repository.RemoveGroup(group.Id);

            _mainWindow.UpdateGroupTable();

            _mainWindow.UpdateAvailableGroupsTable();
            _mainWindow.UpdateDataGridIncludeGroups();
            _mainWindow.UpdateComboBoxProblemGroups();

            this.Hide();
        }
    }
}
