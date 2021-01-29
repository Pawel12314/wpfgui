using Projekt_WPF.models;
using System;
using System.Collections.Generic;

using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Projekt_WPF.conversion2
{
    [ValueConversion(typeof(object), typeof(Brush))]

    class EntryTypeConverter : IValueConverter
    {
        public decimal MaximumPriceToHighlight { get; set; }
        public Brush HighlightBrush { get; set; }
        public Brush DefaultBrush { get; set; }
        

        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
           
            String typeAsString = value == null ? " not found " : value.GetType().Name;
            //MessageBox.Show(s);
            if (typeAsString == "Income")
            {
                return new SolidColorBrush(Colors.LightCoral);
            }
            else if (typeAsString == "Outcome")
            {
                return new SolidColorBrush(Colors.LightBlue);
            }
            else return new SolidColorBrush(Colors.White);
            
            
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
