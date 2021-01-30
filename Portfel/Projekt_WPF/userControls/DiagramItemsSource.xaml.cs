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
    /// Logika interakcji dla klasy DiagramItemsSource.xaml
    /// </summary>
    public partial class DiagramItemsSource : UserControl
    {



        public List<Object> ItemsProperty
        {
            get { return (List<Object>)GetValue(ItemsPropertyProperty); }
            set { SetValue(ItemsPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsPropertyProperty =
            DependencyProperty.Register("ItemsProperty", typeof(List<Object>), typeof(DiagramItemsSource), new PropertyMetadata(new List<object>()));


        public DiagramItemsSource()
        {
            InitializeComponent();
        }
    }
}
