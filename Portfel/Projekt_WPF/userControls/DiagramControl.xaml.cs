using Projekt_WPF.models;
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

namespace Projekt_WPF.userControls
{
    /// <summary>
    /// Logika interakcji dla klasy DiagramControl.xaml
    /// </summary>
    public partial class DiagramControl : UserControl
    {





        public List<String> firstSourceProperty
        {
            get { return (List<String>)GetValue(firstSourcePropertyProperty); }
            set { SetValue(firstSourcePropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for firstSourceProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty firstSourcePropertyProperty =
            DependencyProperty.Register("firstSourceProperty", typeof(List<String>), typeof(DiagramControl), new FrameworkPropertyMetadata(0
                ,
                new PropertyChangedCallback(propertyChangedCallback)
                ));

        public static void propertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           // List<String> list = (List<string>)d;
        }

        public DiagramControl()
        {
            InitializeComponent();

          
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
