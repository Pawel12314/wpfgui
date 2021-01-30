using Projekt_WPF.models;
using Projekt_WPF.ViewModel;
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
        private List<Income> incomes { get; set; }
        
        private List<Outcome> outcomes { get; set; }
        public ChartWindow(MyViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = vm;
            incomes = new List<Income>();
            outcomes = new List<Outcome>();

            for(int i = 0;i<vm.entries.Count;++i)
            {
                Entry e = vm.entries[i];
                if(e is Income)
                {
                    incomes.Add((Income)e);
                }
                else if(e is Outcome)
                {
                    outcomes.Add((Outcome)e);
                }
            }
        },

        
    }
}
