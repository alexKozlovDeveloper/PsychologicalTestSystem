using Db.Core.Helpers;
using Db.Core.Repositoryes;
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
    /// Interaction logic for RemovePassingTestWindow.xaml
    /// </summary>
    public partial class RemovePassingTestWindow : Window
    {
        private readonly ITestingRepository _repository;
        private readonly MainWindow _mainWindow;

        public RemovePassingTestWindow(MainWindow mainWindow, ITestingRepository repository)
        {
            InitializeComponent();

            _repository = repository;
            _mainWindow = mainWindow;

            var allPassingsTest = _repository.GetAllPassingTest();

            var items = new List<PassingTestInfo>();

            foreach (var item in allPassingsTest)
            {
                var test = _repository.GetTest(item.TestId);
                var user = _repository.GetUser(item.UserId);

                var pti = new PassingTestInfo 
                {
                    User = user,
                    PassingTestId = item.Id,
                    TestName = StringHelper.GetShortString(test.Name, 30),
                    Date = item.Date
                };
                
                items.Add(pti);
            }

            ComboBoxPassingTest.Items.Clear();

            foreach (var item in items)
            {
                ComboBoxPassingTest.Items.Add(item);
            }

            if (items.Count != 0)
            {
                ComboBoxPassingTest.SelectedIndex = 0;
            }
        }

        private void ButtonRemovePassingTest_Click(object sender, RoutedEventArgs e)
        {
            var item = ComboBoxPassingTest.SelectedItem as PassingTestInfo;

            _repository.RemovePassingTest(item.PassingTestId);

            this.Hide();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
