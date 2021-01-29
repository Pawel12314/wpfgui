using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Projekt_WPF.conversion2
{
   

    public class ColumnDiagramConversion : IMultiValueConverter
    {
        

        

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                //decimal price = (decimal)values[0];
                // decimal max = (decimal)values[1];
                // MessageBox.Show(max.ToString());
                MessageBox.Show("i am inside converter");
                return 10;
            }
            catch { return 5; }
        }

        

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
