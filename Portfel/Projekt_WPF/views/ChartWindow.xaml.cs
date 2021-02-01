using Projekt_WPF.models;
using Projekt_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Projekt_WPF.views
{
    /// <summary>
    /// Logika interakcji dla klasy ChartWindow.xaml
    /// </summary>
    public partial class ChartWindow : Window
    {


        private ICollectionView view{get;set;}
        private MyViewModel vm { get; set; }
        private ObservableCollection<Income> incomes { get; set; }
        
        private ObservableCollection<Outcome> outcomes { get; set; }
        public ChartWindow(MyViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            DataContext = this.vm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        
    }
}
