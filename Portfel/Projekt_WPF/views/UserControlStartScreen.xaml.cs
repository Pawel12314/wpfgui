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
            vm.deserialize("saveddata.xml");
            addCommmand = new CommandTemplate(o => PrintHello(), o => true);

            InitializeComponent();
            lista = new List<String>();
            lista.Add("abecadlo");
            lista.Add("spadlo");
            lista.Add("piec");
            menu.AddProperty = addCommmand;
          
        }

        private ICommand addCommmand { get; set; }

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
        public class DataPoint
        {
            public double Day { get; set; }
            public double Price { get; set; }
            public double Tax { get; set; }
        } // class

        public class ViewModel
        {
            private readonly Chart _Chart;
            public ObservableCollection<DataPoint> Points { get; private set; }

            public double PriceOfDay3
            {
                get { lock (this) return Points[2].Price; }
                set
                {
                    lock (this)
                    {
                        DataPoint p = Points[2];
                        p.Price = value;
                        Points.Remove(p);
                        Points.Insert(2, p);  // same position          
                                              //Points.Add(p); // append to the end
                    }
                }
            } //

            public ViewModel(Chart xChart)
            {
                _Chart = xChart;
                Points = new ObservableCollection<DataPoint>();

                Points.Add(new DataPoint() { Day = 1.0, Price = 55, Tax = 2.0 });
                Points.Add(new DataPoint() { Day = 1.5, Price = 54, Tax = 1.0 });
                Points.Add(new DataPoint() { Day = 2.0, Price = 58, Tax = -1.0 });
                Points.Add(new DataPoint() { Day = 3.0, Price = 55.5, Tax = 0.0 });
                Points.Add(new DataPoint() { Day = 4.0, Price = 53, Tax = -2.0 });
            } // constructor

        } // class

        private void Window_Initialized(object sender, EventArgs e)
        {
           
        } 
    }
}

