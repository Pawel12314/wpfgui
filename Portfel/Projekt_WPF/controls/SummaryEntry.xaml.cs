using Projekt_WPF.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Projekt_WPF.controls
{
    /// <summary>
    /// Logika interakcji dla klasy SummaryEntry.xaml
    /// </summary>
    public partial class SummaryEntry : UserControl,INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                new PropertyChangedEventArgs(property));
        }


        public SummaryItemEntry summaryProperty
        {
            get { return (SummaryItemEntry)GetValue(summaryPropertyProperty); }
            set { SetValue(summaryPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for summaryProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty summaryPropertyProperty =
            DependencyProperty.Register("summaryProperty", typeof(SummaryItemEntry), typeof(SummaryEntry), new FrameworkPropertyMetadata(null));


        public SummaryEntry()
        {
            Binding binding = new Binding();
            binding.Source = this;
            binding.Path = new PropertyPath("SummaryProperty");
            binding.Mode = BindingMode.TwoWay;
            this.SetBinding(StackPanel.DataContextProperty, binding);
            InitializeComponent();
        }

        private void checkdata(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(summaryProperty.amount.ToString()+" "+summaryProperty.el.name);
        }
        private static void OnMinimumChanged(DependencyObject d,
 DependencyPropertyChangedEventArgs e)
        {
            
        }
    }
}
