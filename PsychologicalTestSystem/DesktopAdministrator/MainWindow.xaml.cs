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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TcpServerLogic;

namespace DesktopAdministrator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TestTcpServer _server;

        public MainWindow()
        {
            InitializeComponent();

            _server = new TestTcpServer();
        }

        private void StartServerButton_Click(object sender, RoutedEventArgs e)
        {
            _server.Start();
        }


    }
}
