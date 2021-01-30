using Projekt_WPF.commands;
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
    /// Logika interakcji dla klasy creationgButtonsControl.xaml
    /// </summary>
    public partial class creationgButtonsControl : UserControl
    {
        public creationgButtonsControl()
        {
            InitializeComponent();
        }
        public int MyWidthProperty
        {
            get { return (int)GetValue(MyWidthPropertyProperty); }
            set { SetValue(MyWidthPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WidthProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyWidthPropertyProperty =
           DependencyProperty.Register("MyWidthProperty", typeof(int), typeof(creationgButtonsControl), new PropertyMetadata(150));



        public ICommand saveProperty
        {
            get { return (ICommand)GetValue(savePropertyProperty); }
            set { SetValue(savePropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty savePropertyProperty =
            DependencyProperty.Register("saveProperty", typeof(ICommand), typeof(creationgButtonsControl), new FrameworkPropertyMetadata(new CommandTemplate(
               o => Print(),
               o => true
               )
                ));



        public ICommand clearProperty
        {
            get { return (ICommand)GetValue(clearPropertyProperty); }
            set { SetValue(clearPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty clearPropertyProperty =
            DependencyProperty.Register("clearProperty", typeof(ICommand), typeof(creationgButtonsControl), new FrameworkPropertyMetadata(new CommandTemplate(
               o => Print(),
               o => true
               )
                ));



        public ICommand closeProperty
        {
            get { return (ICommand)GetValue(closePropertyProperty); }
            set { SetValue(closePropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty closePropertyProperty =
            DependencyProperty.Register("closeProperty", typeof(ICommand), typeof(creationgButtonsControl), new FrameworkPropertyMetadata(new CommandTemplate(
               o => Print(),
               o => true
               )
                ));




        public static void Print()
        {
            MessageBox.Show("hello world from user control");
        }


        public Orientation OrientationProperty
        {
            get { return (Orientation)GetValue(OrientationPropertyProperty); }
            set { SetValue(OrientationPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OrientationProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrientationPropertyProperty =
            DependencyProperty.Register("OrientationProperty", typeof(Orientation), typeof(creationgButtonsControl), new PropertyMetadata(Orientation.Vertical));


        public int MyHeightProperty
        {
            get { return (int)GetValue(MyHeightPropertyProperty); }
            set { SetValue(MyHeightPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyHeightProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyHeightPropertyProperty =
            DependencyProperty.Register("MyHeightProperty", typeof(int), typeof(creationgButtonsControl), new PropertyMetadata(50));


    }
}
