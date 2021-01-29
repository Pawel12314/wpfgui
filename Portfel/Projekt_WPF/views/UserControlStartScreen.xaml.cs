using Projekt_WPF.commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy UserControlStartScreen.xaml
    /// </summary>
    public partial class UserControlStartScreen : Page
    {
        ObservableCollection<String> lista;
        
        
        public UserControlStartScreen()
        {
            addCommmand = new CommandTemplate(o => PrintHello(), o => true);

            InitializeComponent();
            lista = new ObservableCollection<String>();
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

        }
    }
}

