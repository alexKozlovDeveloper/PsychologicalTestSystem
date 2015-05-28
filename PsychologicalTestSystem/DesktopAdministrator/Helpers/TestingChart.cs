using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DesktopAdministrator.Helpers
{
    public class TestingChart
    {
        private Grid _grid;
        private int _itemCount;

        private int _itemHeight = 20;
        private int _itemWidth = 200;

        public TestingChart(Grid grid)
        {
            _grid = grid;

            //_grid.Height = 900;
            //_grid.Width = 400;


            var w = 200;

            var rec1 = new Rectangle();
            rec1.Height = w;
            rec1.Width = 1;
            rec1.Margin = new Thickness(0, 0, 0, 0);
            rec1.Fill = new SolidColorBrush(System.Windows.Media.Colors.Gray);

            var rec2 = new Rectangle();
            rec2.Height = w;
            rec2.Width = 1;
            rec2.Margin = new Thickness(2 * w, 0, 0, 0);
            rec2.Fill = new SolidColorBrush(System.Windows.Media.Colors.Gray);

            var rec3 = new Rectangle();
            rec3.Height = 1;
            rec3.Width = w;
            rec3.Margin = new Thickness(0, 0, 0, 0);
            rec3.Fill = new SolidColorBrush(System.Windows.Media.Colors.Gray);

            var rec4 = new Rectangle();
            rec4.Height = 1;
            rec4.Width = w;
            rec4.Margin = new Thickness(0, w, 0, 0);
            rec4.Fill = new SolidColorBrush(System.Windows.Media.Colors.Gray);

            //_grid.Children.Add(rec1);
            //_grid.Children.Add(rec2);
            //_grid.Children.Add(rec3);
            //_grid.Children.Add(rec4);

            _itemCount = 0;
        }

        public void AddItem(TestingChartItem item)
        {
            var label = new Label();

            label.Content = item.Number;
            label.Margin = new Thickness(285, 22 + _itemCount * _itemHeight, 0, 0);

            var labelVal1 = new Label();

            labelVal1.Content = item.AveragePercent + " %";
            labelVal1.Margin = new Thickness(15, 22 + _itemCount * _itemHeight, 0, 0);

            var labelVal2 = new Label();

            labelVal2.Content = item.HighPercent + " %";
            labelVal2.Margin = new Thickness(560, 22 + _itemCount * _itemHeight, 0, 0);

            var rec1 = new Rectangle();

            rec1.Margin = new Thickness(71 + 200 - item.AveragePercent * 2, 30 + _itemCount * _itemHeight, _grid.Width - 270, _grid.Height - (30 + _itemCount * _itemHeight) - 10);
            rec1.Fill = new SolidColorBrush(System.Windows.Media.Colors.LightSeaGreen);

            var rec2 = new Rectangle();

            rec2.Margin = new Thickness(330, 30 + _itemCount * _itemHeight, _grid.Width - 330 - item.HighPercent * 2, _grid.Height - (30 + _itemCount * _itemHeight) - 10);
            rec2.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkOrange);

            _grid.Children.Add(rec1);
            _grid.Children.Add(rec2);
            _grid.Children.Add(label);
            _grid.Children.Add(labelVal1);
            _grid.Children.Add(labelVal2);

            _itemCount++;
        }
    }
}
