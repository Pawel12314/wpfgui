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

    [ValueConversion(typeof(object), typeof(decimal))]
    public class ColumnDiagramConversion : IValueConverter
    {
        

        

  /*      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
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
*/
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                //decimal price = (decimal)values[0];
                // decimal max = (decimal)values[1];
                // MessageBox.Show(max.ToString());
                MessageBox.Show("i am inside converter");
                return 100*(int)value;
            }
            catch { return 250; }
        }

        /*public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }*/

          public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
       }
}
