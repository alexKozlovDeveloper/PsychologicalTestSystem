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
            //var grid = new Grid();

            //grid.Width = _itemWidth;
            //grid.Height = _itemHeight;

            //grid.Margin = new Thickness(10, _itemCount * _itemHeight + 5, 0, 0);

            var label = new Label();

            label.Content = item.Number;
            label.Margin = new Thickness(285, 22 + _itemCount * _itemHeight, 0, 0);

            var labelVal = new Label();

            labelVal.Content = item.AveragePercent + " %";
            labelVal.Margin = new Thickness(15, 22 + _itemCount * _itemHeight, 0, 0);

            var rec1 = new Rectangle();

            //rec1.Height = 10;
            //rec1.Width = 10;//item.AveragePercent * 2;

            //rec1.Margin = new Thickness(10 + 200 - item.AveragePercent * 2, 
            //    20 + _itemCount * _itemHeight - 400, 
            //    90, 
            //    0);

            rec1.Margin = new Thickness(71 + 200 - item.AveragePercent * 2, 30 + _itemCount * _itemHeight, _grid.Width - 270, _grid.Height - (30 + _itemCount * _itemHeight) - 10);

            rec1.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkOrange);



            //grid.Children.Add(rec1);
            //grid.Children.Add(label);


            //_grid.Children.Add(grid);
            _grid.Children.Add(rec1);
            _grid.Children.Add(label);
            _grid.Children.Add(labelVal);

            _itemCount++;
        }
    }
}
