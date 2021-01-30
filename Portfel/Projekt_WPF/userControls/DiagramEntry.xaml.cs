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
    /// Logika interakcji dla klasy DiagramEntry.xaml
    /// </summary>
    public partial class DiagramLabel : UserControl
    {



        public String LabelProperty
        {
            get { return (String)GetValue(LabelPropertyProperty); }
            set { SetValue(LabelPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelPropertyProperty =
            DependencyProperty.Register("LabelProperty", typeof(String), typeof(DiagramLabel), new PropertyMetadata("not defined"));


        public DiagramLabel()
        {
            InitializeComponent();
        }
    }
}
