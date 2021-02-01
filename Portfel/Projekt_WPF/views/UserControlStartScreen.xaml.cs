using Projekt_WPF.commands;
using Projekt_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
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
    /// Logika interakcji dla klasy UserControlStartScreen.xaml
    /// </summary>
    public partial class UserControlStartScreen : Page
    {
        List<String> lista;
        private MyViewModel vm { get; set; }
        
        public UserControlStartScreen(MyViewModel vm)
        {
            this.vm = vm;
            //vm.deserialize("saveddata.xml");
          

            InitializeComponent();
          
            
          
        }

       

        public static void PrintHello()
        {
            MessageBox.Show("hello from start screen");
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //addCommmand = new CommandTemplate(o=>PrintHello(), o => true);
            //addCommmand = new DelegateCommand(o=>PrintHello(), o => true);
            //ViewModel lViewModel = new ViewModel(Chart1);
            DataContext = vm;
        }
      
    }
}

