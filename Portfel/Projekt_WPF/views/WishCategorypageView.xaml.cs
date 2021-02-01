using Projekt_WPF.commands;
using Projekt_WPF.models;

using Projekt_WPF.ViewModel;
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

namespace Projekt_WPF.views
{
    /// <summary>
    /// Logika interakcji dla klasy newCategorypageView.xaml
    /// </summary>
    public partial class newwishCategorypageView : Page
    {
    
        private MyViewModel vm { get; set; }

        private ICommand addCMD { get; set; }
        private ICommand editCMD { get; set; }
        private ICommand deleteCMD { get; set; }
        public newwishCategorypageView(MyViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            
        }

        private void openEdittwindow()
        {

            if(categoryListBox.SelectedItem!=null)
            {
                WishGroup w = (WishGroup)categoryListBox.SelectedItem;
                var editwindow = new addwishNewCategory(w);
                MessageBox.Show("opening edit window+ ", w.name);
                editwindow.Show();
            }
            
            else
            {
                MessageBox.Show("nie wybrano nic w liscie");
            }
           
        }
        private void deleteWishGroup()
        {
            WishGroup w =(WishGroup) categoryListBox.SelectedItem;
            ((MainWindow)Application.Current.MainWindow).deleteWishgorup(w);
        }
        private void opennewWindow()
        {
            MessageBox.Show("opening new menu creatr");
            new addwishNewCategory(null).Show();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            categoryListBox.ItemsSource = vm.wishgroups;
            addCMD = new CommandTemplate(o =>opennewWindow(), o => true);
            editCMD = new CommandTemplate(o=>openEdittwindow(), o => true);

            menubuttons.EditProperty = editCMD;
            menubuttons.AddProperty = addCMD;
        }
    }
}
