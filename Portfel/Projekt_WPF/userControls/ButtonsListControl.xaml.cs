using Projekt_WPF.commands;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_WPF.userControls
{
    /// <summary>
    /// Logika interakcji dla klasy ButtonsListControl.xaml
    /// </summary>
    public partial class ButtonsListControl : UserControl
    {

     
        public int MyWidthProperty
        {
            get { return (int)GetValue(MyWidthPropertyProperty); }
            set { SetValue(MyWidthPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WidthProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyWidthPropertyProperty =
           DependencyProperty.Register("MyWidthProperty", typeof(int), typeof(ButtonsListControl), new PropertyMetadata(150));



        public ICommand AddProperty
        {
            get { return (ICommand)GetValue(AddPropertyProperty); }
            set { SetValue(AddPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddPropertyProperty =
            DependencyProperty.Register("AddProperty", typeof(ICommand), typeof(ButtonsListControl), new FrameworkPropertyMetadata(new CommandTemplate(
               o => Print(),
               o => true
               )
                ));



        public ICommand EditProperty
        {
            get { return (ICommand)GetValue(EditPropertyProperty); }
            set { SetValue(EditPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditPropertyProperty =
            DependencyProperty.Register("EditProperty", typeof(ICommand), typeof(ButtonsListControl), , new FrameworkPropertyMetadata(new CommandTemplate(
               o => Print(),
               o => true
               )
                ));



        public ICommand DeleteProperty
        {
            get { return (ICommand)GetValue(DeletePropertyProperty); }
            set { SetValue(DeletePropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeletePropertyProperty =
            DependencyProperty.Register("DeleteProperty", typeof(ICommand), typeof(ButtonsListControl), , new FrameworkPropertyMetadata(new CommandTemplate(
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
            DependencyProperty.Register("OrientationProperty", typeof(Orientation), typeof(ButtonsListControl), new PropertyMetadata(Orientation.Vertical));


        public int MyHeightProperty
        {
            get { return (int)GetValue(MyHeightPropertyProperty); }
            set { SetValue(MyHeightPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyHeightProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyHeightPropertyProperty =
            DependencyProperty.Register("MyHeightProperty", typeof(int), typeof(ButtonsListControl), new PropertyMetadata(50));


        private static ICommand cmd { get; set; }
        static ButtonsListControl()
        {
            //cmd = 
            
            //InputBindings.Add(cancelKB);
        }
      

        public ButtonsListControl()
        {
            InitializeComponent();
       
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //AddProperty.Execute(1);
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            AddProperty.Execute(1);
        }
    }
}
