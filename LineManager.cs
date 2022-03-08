using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.DataVisualization.Charting;

namespace CalendarSolution
{
    public class LineManager
    {
        public ColumnSeries Line1 = new ColumnSeries();
        public LineManager()
        {
            Line1.Title = "Test";

            List<KeyValuePair<int, int>> testList = new List<KeyValuePair<int, int>>();
            testList.Add(new KeyValuePair<int, int>(1, 2));
            testList.Add(new KeyValuePair<int, int>(2, 3));

            Line1.IndependentValueBinding = new System.Windows.Data.Binding("key");
            Line1.DependentValueBinding = new System.Windows.Data.Binding("value");
            Line1.ItemsSource = testList;
        }
    }
}
