using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Core.TableEntityes
{
    public class TestingChartItem : IComparable
    {
        public int AveragePercent { get; set; }
        public int HighPercent { get; set; }
        public int Number { get; set; }

        public int CompareTo(object obj)
        {
            var item = obj as TestingChartItem;

            return Number.CompareTo(item.Number);
        }
    }
}
