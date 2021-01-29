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

namespace Projekt_WPF.views
{
    /// <summary>
    /// Logika interakcji dla klasy UserControlPersonalize.xaml
    /// </summary>
    public partial class UserControlPersonalize : Page
    {
        public UserControlPersonalize()
        {
            InitializeComponent();
        }

        private void startScreenColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            
        }

        private void fontSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            fontSizeLabel.Content = fontSizeSlider.Value;
            fontSizeLabel.FontSize = fontSizeSlider.Value;
        }

        private void fontSizeConfirmAllButton_Click(object sender, RoutedEventArgs e)
        {
            globalSettings.GlobalSettings.FontSize = fontSizeSlider.Value;
        }
        private void everywhereConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            globalSettings.GlobalSettings.SetAllColorsTo(new SolidColorBrush((Color)everywhereColorPicker.SelectedColor));
        }
        private void startScreenConfirmOneButton_Click(object sender, RoutedEventArgs e)
        {
            globalSettings.GlobalSettings.StartScreenColor = new SolidColorBrush((Color)startScreenColorPicker.SelectedColor);
        }

        private void entryScreenConfirmOneButton_Click(object sender, RoutedEventArgs e)
        {
            globalSettings.GlobalSettings.EntryScreenColor = new SolidColorBrush((Color)entryScreenColorPicker.SelectedColor);
        }

        private void categoryScreenConfirmOneButton_Click(object sender, RoutedEventArgs e)
        {
            globalSettings.GlobalSettings.CategoryScreenColor = new SolidColorBrush((Color)categoryScreenColorPicker.SelectedColor);
        }
        private void summaryScreenConfirmOneButton_Click(object sender, RoutedEventArgs e)
        {
            globalSettings.GlobalSettings.SummaryScreenColor = new SolidColorBrush((Color)summaryScreenColorPicker.SelectedColor);
        }

        private void personalizeScreenConfirmOneButton_Click(object sender, RoutedEventArgs e)
        {
            globalSettings.GlobalSettings.PersonalizeScreenColor = new SolidColorBrush((Color)personalizeScreenColorPicker.SelectedColor);
        }

        private void popUpWindowsConfirmOneButton_Click(object sender, RoutedEventArgs e)
        {
            globalSettings.GlobalSettings.WindowScreenColor = new SolidColorBrush((Color)popUpWindowsColorPicker.SelectedColor);
        }

    }
}
